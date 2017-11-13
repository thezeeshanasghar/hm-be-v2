using AutoMapper;
using HM_API_V3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HM_API_V3.Controllers
{
    public class AccountController : BaseController
    {
        #region C R U D

        public Response<IEnumerable<AccountDTO>> Get()
        {
            try
            {
                


                using (HMEntities1 entities = new HMEntities1())
                {
                    var dbVaccines = entities.Accounts.ToList();
                    IEnumerable<AccountDTO> AccountDTOs = Mapper.Map<IEnumerable<AccountDTO>>(dbVaccines);
                    return new Response<IEnumerable<AccountDTO>>(true, null, AccountDTOs);
                }
            }
            catch (Exception e)
            {
                return new Response<IEnumerable<AccountDTO>>(false, GetMessageFromExceptionObject(e), null);

            }
        }

        public Response<AccountDTO> Get(int Id)
        {
            try
            {
                using (HMEntities1 entities = new HMEntities1())
                {
                    var dbVaccine = entities.Accounts.Where(c => c.Id == Id).FirstOrDefault();
                    AccountDTO AccountDTO = Mapper.Map<AccountDTO>(dbVaccine);
                    return new Response<AccountDTO>(true, null, AccountDTO);
                }
            }
            catch (Exception e)
            {
                return new Response<AccountDTO>(false, GetMessageFromExceptionObject(e), null);

            }

        }

        public Response<AccountDTO> Post(AccountDTO AccountDTO)
        {
            try
            {

                using (HMEntities1 entities = new HMEntities1())
                {
                    Account vaccinedb = Mapper.Map<Account>(AccountDTO);
                    entities.Accounts.Add(vaccinedb);
                    entities.SaveChanges();
                    AccountDTO.Id = vaccinedb.Id;

                    return new Response<AccountDTO>(true, null, AccountDTO);

                }
            }
            catch (Exception e)
            {
                return new Response<AccountDTO>(false, GetMessageFromExceptionObject(e), null);

            }
        }
        public Response<AccountDTO> Put(int Id, AccountDTO AccountDTO)
        {
            try
            {
                using (HMEntities1 entities = new HMEntities1())
                {
                    var dbVaccine = entities.Accounts.Where(c => c.Id == Id).FirstOrDefault();
                    dbVaccine = Mapper.Map<AccountDTO, Account>(AccountDTO, dbVaccine);
                    entities.SaveChanges();
                    return new Response<AccountDTO>(true, null, AccountDTO);
                }
            }
            catch (Exception e)
            {
                return new Response<AccountDTO>(false, GetMessageFromExceptionObject(e), null);

            }
        }

        public Response<string> Delete(int Id)
        {
            try
            {
                using (HMEntities1 entities = new HMEntities1())
                {
                    var dbVaccine = entities.Accounts.Where(c => c.Id == Id).FirstOrDefault();
                    entities.Accounts.Remove(dbVaccine);
                    entities.SaveChanges();
                    return new Response<string>(true, null, "record deleted");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                    return new Response<string>(false, "Cannot delete Account because related record exists in database.", null);
                else
                    return new Response<string>(false, GetMessageFromExceptionObject(ex), null);
            }
        }

        #endregion
    }
}
