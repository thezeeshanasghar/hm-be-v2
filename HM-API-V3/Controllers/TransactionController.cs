using AutoMapper;
using HM_API_V3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace HM_API_V3.Controllers
{
    public class TransactionController : BaseController
    {
        #region C R U D


        public Response<TransactionWithPreviousBalanceDTO> GET(string date="")
        {
            TransactionWithPreviousBalanceDTO obj = new TransactionWithPreviousBalanceDTO();
            try
            {
                using (HMEntities1 db = new HMEntities1())
                {
                    DateTime now = DateTime.Now;
                    if (!String.IsNullOrEmpty(date))
                        now = Convert.ToDateTime(date);

                    var transactions = db.Transactions.Where(x=>x.Date==now).ToList();
                    IEnumerable<TransactionDTO> transactionDTOs = Mapper.Map<IEnumerable<TransactionDTO>>(transactions);

                    obj.Transactions = transactionDTOs.ToList();
                    obj.PreviousBalance = db.Transactions.Where(x => x.Date != now).Sum(x=>x.Amount);


                    return new Response<TransactionWithPreviousBalanceDTO>(true, null, obj);
                }
            }
            catch (Exception ex)
            {
                return new Response<TransactionWithPreviousBalanceDTO>(false, GetMessageFromExceptionObject(ex), null);
            }
        }


        public Response<TransactionDTO> Get(int Id)
        {
            try
            {
                using (HMEntities1 entities = new HMEntities1())
                {
                    var dbTransaction = entities.Transactions.Where(c => c.Id == Id).FirstOrDefault();
                    TransactionDTO transactionDTO = Mapper.Map<TransactionDTO>(dbTransaction);
                    return new Response<TransactionDTO>(true, null, transactionDTO);
                }
            }
            catch (Exception e)
            {
                return new Response<TransactionDTO>(false, GetMessageFromExceptionObject(e), null);
            }

        }

        public Response<TransactionDTO> Post(TransactionDTO transactionDTO)
        {
            try
            {

                using (HMEntities1 entities = new HMEntities1())
                {
                    Transaction dbTransaction = Mapper.Map<Transaction>(transactionDTO);
                    entities.Transactions.Add(dbTransaction);
                    entities.SaveChanges();
                    transactionDTO.Id = dbTransaction.Id;

                    updateAccountBalance(entities, dbTransaction);


                    return new Response<TransactionDTO>(true, null, transactionDTO);
                }
            }
            catch (Exception e)
            {
                return new Response<TransactionDTO>(false, GetMessageFromExceptionObject(e), null);
            }
        }
        public Response<TransactionDTO> Put(int Id, TransactionDTO transactionDTO)
        {
            try
            {
                using (HMEntities1 entities = new HMEntities1())
                {
                    var dbTransaction = entities.Transactions.Where(c => c.Id == Id).FirstOrDefault();
                    if (dbTransaction == null)
                        return new Response<TransactionDTO>(false, "Transaction not found", null);
                    dbTransaction = Mapper.Map<TransactionDTO, Transaction>(transactionDTO, dbTransaction);
                    entities.SaveChanges();
                    updateAccountBalance(entities, dbTransaction);

                    return new Response<TransactionDTO>(true, null, transactionDTO);
                }
            }
            catch (Exception e)
            {
                return new Response<TransactionDTO>(false, GetMessageFromExceptionObject(e), null);
            }
        }


        public Response<string> Delete(int Id)
        {
            try
            {
                using (HMEntities1 entities = new HMEntities1())
                {
                    var dbTransaction = entities.Transactions.Where(c => c.Id == Id).FirstOrDefault();
                    entities.Transactions.Remove(dbTransaction);
                    entities.SaveChanges();
                    updateAccountBalance(entities, dbTransaction);

                    return new Response<string>(true, null, "record deleted");
                }
            }
            catch (Exception ex)
            {
                return new Response<string>(false, GetMessageFromExceptionObject(ex), null);
            }
        }


        #endregion


        private void updateAccountBalance(HMEntities1 entities, Transaction dbTransaction)
        {
            Account account = entities.Accounts.FirstOrDefault(x => x.Id == dbTransaction.AccountID);
            account.Balance = account.Transactions.Sum(x => x.Amount);
            entities.SaveChanges();
        }

    }

}
