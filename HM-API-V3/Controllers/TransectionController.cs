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
    public class TransectionController : BaseController
    {



       // [Route("api/transection")]

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

    }
}
