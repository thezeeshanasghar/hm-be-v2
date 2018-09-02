using AutoMapper;
using HM_API_V4.Models;
using HM_API_V4.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HM_API_V4.Controllers
{
    public class CarPurchaseController : BaseController
    {
        public Response<CarPurchaseDTO> Post(CarPurchaseDTO cpDTO)
        {
            try
            {

                using (HMEntities1 entities = new HMEntities1())
                {
                    CarPurchase cpDB = Mapper.Map<CarPurchase>(cpDTO);
                    cpDB.Buyers.Clear();
                    cpDB.Sellers.Clear();
                    cpDB.Witnesses.Clear();

                    foreach (var witness in cpDTO.Witnesses)
                    {
                        var witnessDB = Mapper.Map<Witness>(witness);
                        entities.Witnesses.Add(witnessDB);
                        entities.SaveChanges();
                        cpDB.Witnesses.Add(witnessDB);
                    }
                    entities.CarPurchases.Add(cpDB);
                    entities.SaveChanges();
                    cpDTO.Id = cpDB.Id;
                    cpDTO.Witnesses = Mapper.Map<List<WitnessDTO>>(cpDB.Witnesses);
                    foreach (var account in cpDTO.Sellers)
                    {
                        Account dbAccount = entities.Accounts.FirstOrDefault(s => s.Id == account.Id);
                        cpDB.Sellers.Add(dbAccount);
                        entities.SaveChanges();
                    }
                    cpDTO.Sellers = Mapper.Map<List<AccountDTO>>(cpDB.Sellers);
                    foreach (var account in cpDTO.Buyers)
                    {
                        Account dbAccount = entities.Accounts.FirstOrDefault(s => s.Id == account.Id);
                        cpDB.Buyers.Add(dbAccount);
                        entities.SaveChanges();
                    }
                    cpDTO.Buyers = Mapper.Map<List<AccountDTO>>(cpDB.Buyers);


                    var car = entities.Cars.FirstOrDefault(s => s.Id == cpDTO.CarID);
                    car.Accounts = cpDB.Buyers;
                    entities.SaveChanges();
                    cpDB.Car = car;
                    cpDTO.Car = Mapper.Map<CarDTO>(cpDB.Car);

                    cpDTO.Id = cpDB.Id;


                    return new Response<CarPurchaseDTO>(true, null, cpDTO);
                }
            }
            catch (Exception e)
            {
                return new Response<CarPurchaseDTO>(false, GetMessageFromExceptionObject(e), null);
            }

        }
    }
}