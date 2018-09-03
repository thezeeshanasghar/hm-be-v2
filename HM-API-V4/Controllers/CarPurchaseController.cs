﻿using AutoMapper;
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
                t.Account = cpDB.Sellers.ElementAt(0);
                t.AccountID = t.Account.Id;
                t.Amount = cpDB.Price;
                t.Date = DateTime.Now.Date;
                t.Description = "Sell Car " + cpDB.Car.RegistrationNumber;
                db.Transactions.Add(t);
                db.SaveChanges();

                t = new Transaction();
                t.Account = cpDB.Sellers.ElementAt(0);
                t.AccountID = t.Account.Id;
                t.Amount = -1 * cpDB.SellerCom;
                t.Date = DateTime.Now.Date;
                t.Description = "Pay commision for car " + cpDB.Car.RegistrationNumber;
                db.Transactions.Add(t);

                t = new Transaction();
                t.Account = db.Accounts.ElementAt(0);
                t.AccountID = t.Account.Id;
                t.Amount = cpDB.SellerCom;
                t.Date = DateTime.Now.Date;
                t.Description = "Receive commision in deal of a car " + cpDB.Car.RegistrationNumber;
                db.Transactions.Add(t);

                // buyers
                t = new Transaction();
                t.Account = cpDB.Buyers.ElementAt(0);
                t.AccountID = t.Account.Id;
                t.Amount = -1 * cpDB.Price;
                t.Date = DateTime.Now.Date;
                t.Description = "Buy Car " + cpDB.Car.RegistrationNumber;
                db.Transactions.Add(t);
                db.SaveChanges();

                t = new Transaction();
                t.Account = cpDB.Sellers.ElementAt(0);
                t.AccountID = t.Account.Id;
                t.Amount = -1 * cpDB.BuyerCom;
                t.Date = DateTime.Now.Date;
                t.Description = "Pay commision for car " + cpDB.Car.RegistrationNumber;
                db.Transactions.Add(t);

                t = new Transaction();
                t.Account = db.Accounts.ElementAt(0);
                t.AccountID = t.Account.Id;
                t.Amount = cpDB.BuyerCom;
                t.Date = DateTime.Now.Date;
                t.Description = "Receive commision in deal of a car " + cpDB.Car.RegistrationNumber;
                db.Transactions.Add(t);



                return new Response<CarPurchaseDTO>(true, null, cpDTO);
            }
            catch (Exception e)
            {
                return new Response<CarPurchaseDTO>(false, GetMessageFromExceptionObject(e), null);
            }

        }
    }
}