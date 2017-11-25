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
        public Response<IEnumerable<TransactionDTO>> GET()
        {
            try
            {
                using (HMEntities1 db = new HMEntities1())
                {
                    var Transections = db.Transactions.ToList();
                    IEnumerable<TransactionDTO> transactionDTOs = Mapper.Map<IEnumerable<TransactionDTO>>(Transections);
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
                    Account c = entities.Accounts.FirstOrDefault(x=>x.Id==dbTransaction.AccountID);
                    c.Balance += dbTransaction.Amount;
                    entities.SaveChanges();

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
                    return new Response<string>(true, null, "record deleted");
                }
            }
            catch (Exception ex)
            {
                return new Response<string>(false, GetMessageFromExceptionObject(ex), null);
            }
        }

    }

}
