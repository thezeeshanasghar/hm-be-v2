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


        public Response<IEnumerable<TransactionDTO>> GET(string year="", string month="")
        {
            try
            {
                using (HMEntities1 db = new HMEntities1())
                {
                    DateTime now = DateTime.Now;

                    //if(year!=null && month !=null && year > 2000 && year < 3000 && month > 0 && month < 13)
                    //    now = new DateTime(year.Value, month.Value, 1);

                    var startDate = new DateTime(now.Year, now.Month, 1);
                    var endDate = startDate.AddMonths(1).AddDays(-1);

                    var transactions = db.Transactions.Where(x=>x.Date>= startDate && x.Date <= endDate).ToList();
                    IEnumerable<TransactionDTO> transactionDTOs = Mapper.Map<IEnumerable<TransactionDTO>>(transactions);

                    return new Response<IEnumerable<TransactionDTO>>(true, null, transactionDTOs);
                }
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<TransactionDTO>>(false, GetMessageFromExceptionObject(ex), null);
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


        private static void updateAccountBalance(HMEntities1 entities, Transaction dbTransaction)
        {
            Account account = dbTransaction.Account;
            account.Balance = entities.Transactions.Where(c => c.AccountID == account.Id).Sum(x => x.Amount);
            entities.SaveChanges();
        }

    }

}
