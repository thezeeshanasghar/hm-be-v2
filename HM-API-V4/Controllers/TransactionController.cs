using AutoMapper;
using HM_API_V4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Globalization;

namespace HM_API_V4.Controllers
{
    public class TransactionController : BaseController
    {
        #region C R U D


        public Response<TransactionWithPreviousBalanceDTO> GET(int accountId=0, string date="")
        {
            //TODO: return data should entertain accountId parameter as well
            TransactionWithPreviousBalanceDTO obj = new TransactionWithPreviousBalanceDTO();
            try
            {
                using (HMEntities1 db = new HMEntities1())
                {
                    DateTime now = DateTime.Now;
                    if (!String.IsNullOrEmpty(date))
                        now = DateTime.ParseExact(date, "d", CultureInfo.InvariantCulture);

                    var transactions = db.Transactions.Where(x => EntityFunctions.TruncateTime(x.Date) == EntityFunctions.TruncateTime(now)).ToList();
                    obj.Transactions = (Mapper.Map<IEnumerable<TransactionDTO>>(transactions)).ToList();

                    var previousTransactions = db.Transactions.Where(x => EntityFunctions.TruncateTime(x.Date) < EntityFunctions.TruncateTime(now));
                    if (previousTransactions.Count() == 0)
                    {
                        obj.PreviousBalance = 0;
                        obj.RemainingBalance = transactions.Sum(x => x.Amount);
                    }
                    else
                    {
                        obj.PreviousBalance = previousTransactions.Sum(x => x.Amount);
                        obj.RemainingBalance = obj.PreviousBalance + transactions.Sum(x => x.Amount);
                    }

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
                    dbTransaction.Number = Guid.NewGuid().ToString();
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
                    dbTransaction.Amount = transactionDTO.Amount;
                    dbTransaction.Description = transactionDTO.Description;
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
