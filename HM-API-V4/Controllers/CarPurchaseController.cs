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
        private HMEntities1 db = new HMEntities1();

        public IEnumerable<CarPurchaseDTO> GetAll()
        {
            var dbObjs = db.CarPurchases.ToList();
            List<CarPurchaseDTO> dtoObjs = Mapper.Map<List<CarPurchaseDTO>>(dbObjs);
            return dtoObjs;
        }

        public Response<CarPurchaseDTO> Post(CarPurchaseDTO cpDTO)
        {
            try
            {
                CarPurchase cpDB = Mapper.Map<CarPurchase>(cpDTO);
                cpDB.Buyers.Clear();
                cpDB.Sellers.Clear();
                cpDB.Witnesses.Clear();

                foreach (var witness in cpDTO.Witnesses)
                {
                    var witnessDB = Mapper.Map<Witness>(witness);
                    db.Witnesses.Add(witnessDB);
                    db.SaveChanges();
                    cpDB.Witnesses.Add(witnessDB);
                }
                db.CarPurchases.Add(cpDB);
                db.SaveChanges();
                cpDTO.Id = cpDB.Id;
                cpDTO.Witnesses = Mapper.Map<List<WitnessDTO>>(cpDB.Witnesses);
                foreach (var account in cpDTO.Sellers)
                {
                    Account dbAccount = db.Accounts.FirstOrDefault(s => s.Id == account.Id);
                    cpDB.Sellers.Add(dbAccount);
                    db.SaveChanges();
                }
                cpDTO.Sellers = Mapper.Map<List<AccountDTO>>(cpDB.Sellers);
                foreach (var account in cpDTO.Buyers)
                {
                    Account dbAccount = db.Accounts.FirstOrDefault(s => s.Id == account.Id);
                    cpDB.Buyers.Add(dbAccount);
                    db.SaveChanges();
                }
                cpDTO.Buyers = Mapper.Map<List<AccountDTO>>(cpDB.Buyers);


                var car = db.Cars.FirstOrDefault(s => s.Id == cpDTO.CarID);
                car.Accounts = cpDB.Buyers;
                db.SaveChanges();
                cpDB.Car = car;
                cpDTO.Car = Mapper.Map<CarDTO>(cpDB.Car);

                cpDTO.Id = cpDB.Id;

                // sellers
                Transaction t = new Transaction();
                foreach (Account seller in cpDB.Sellers) {
                    t.Account = seller;
                    t.AccountID = seller.Id;
                    t.Date = DateTime.Now.Date;

                    t.Number = Guid.NewGuid().ToString();
                    t.Amount = cpDB.Sellers.Count == 2  ? (cpDB.Price/(decimal)2.0) : cpDB.Price;
                    t.Description = "Sell Car " + cpDB.Car.RegistrationNumber;

                    db.Transactions.Add(t);
                    db.SaveChanges();

                    t = new Transaction();
                    t.Account = seller;
                    t.AccountID = seller.Id;
                    t.Date = DateTime.Now.Date;
                    t.Number = Guid.NewGuid().ToString();
                    t.Amount = -1 * (cpDB.Sellers.Count == 2 ? (cpDB.SellerCom / (decimal)2.0) : cpDB.SellerCom);
                    t.Description = "Pay commision for car " + cpDB.Car.RegistrationNumber;
                    db.Transactions.Add(t);
                    db.SaveChanges();
                }

                // commision, TODO: HM
                t = new Transaction();
                t.Number = Guid.NewGuid().ToString();
                t.Account = db.Accounts.First(x => x.Id == 1);
                t.AccountID = t.Account.Id;
                t.Amount = cpDB.SellerCom;
                t.Date = DateTime.Now.Date;
                t.Description = "Receive seller commision in car deal" + cpDB.Car.RegistrationNumber;
                db.Transactions.Add(t);

                // buyers

                foreach (Account buyer in cpDB.Buyers)
                {
                    t = new Transaction();
                    t.Account = buyer;
                    t.AccountID = buyer.Id;
                    t.Date = DateTime.Now.Date;
                    t.Number = Guid.NewGuid().ToString();
                    t.Amount = -1 * (cpDB.Buyers.Count == 2 ? (cpDB.Price / (decimal)2.0) : cpDB.Price);
                    t.Description = "Buy Car " + cpDB.Car.RegistrationNumber;
                    db.Transactions.Add(t);
                    db.SaveChanges();

                    t = new Transaction();
                    t.Account = buyer;
                    t.AccountID = buyer.Id;
                    t.Date = DateTime.Now.Date;
                    t.Amount = -1 * (cpDB.Sellers.Count == 2 ? (cpDB.BuyerCom / (decimal)2.0) : cpDB.BuyerCom);
                    t.Number = Guid.NewGuid().ToString();
                    t.Description = "Pay buyer commision for car " + cpDB.Car.RegistrationNumber;
                    db.Transactions.Add(t);
                    db.SaveChanges();
                }

                t = new Transaction();
                t.Number = Guid.NewGuid().ToString();
                t.Account = db.Accounts.First(x => x.Id == 1);
                t.AccountID = t.Account.Id;
                t.Amount = cpDB.BuyerCom;
                t.Date = DateTime.Now.Date;
                t.Description = "Receive commision in deal of a car " + cpDB.Car.RegistrationNumber;
                db.Transactions.Add(t);
                db.SaveChanges();

                updateAllAccountBalance(db);


                return new Response<CarPurchaseDTO>(true, null, cpDTO);
            }
            catch (Exception e)
            {
                return new Response<CarPurchaseDTO>(false, GetMessageFromExceptionObject(e), null);
            }

        }
    }
}