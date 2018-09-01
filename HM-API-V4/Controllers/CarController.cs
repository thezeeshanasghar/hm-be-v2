using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HM_API_V4;
using HM_API_V4.Models;
using AutoMapper;

namespace HM_API_V4.Controllers
{
    public class CarController : ApiController
    {
        private HMEntities1 db = new HMEntities1();
        #region C R U D
        // GET: api/Car
        public IEnumerable<CarDTO> GetCars()
        {
            var dbCars = db.Cars.ToList();
            List<CarDTO> carDTOs = Mapper.Map<List<CarDTO>>(dbCars);
            return carDTOs;
        }

        // GET: api/Car/5
        [ResponseType(typeof(CarDTO))]
        public IHttpActionResult GetCar(long id)
        {
            //TODO: Single car with accounts
            CarDTO carDto = Mapper.Map<CarDTO>(db.Cars.Find(id));
            if (carDto == null)
            {
                return NotFound();
            }

            return Ok(carDto);
        }

        // PUT: api/Car/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCar(long id, Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != car.Id)
            {
                return BadRequest();
            }

            db.Entry(car).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Car
        [ResponseType(typeof(CarDTO))]
        public HttpResponseMessage PostCar(CarDTO obj)
        {
            try
            {
                var dbCar = Mapper.Map<Car>(obj);
                foreach(var account in obj.Owners)
                {
                    //Transaction dbTransaction = new Transaction();
                    Account dbAccount = db.Accounts.FirstOrDefault(s => s.Id == account.Id);
                    dbCar.Accounts.Add(dbAccount);
                    //dbTransaction.AccountID = account.Id;
                    //dbTransaction.Date = DateTime.Now;
                    //dbTransaction.Amount = dbCar.PurchasePrice;
                    //dbTransaction.Number = dbCar.RegistrationNumber;
                    //dbTransaction.Description = "test";
                    //db.Transactions.Add(dbTransaction);
                } 
                db.Cars.Add(dbCar);
                db.SaveChanges();
                obj.Id = dbCar.Id;
                obj.Owners =Mapper.Map<List<AccountDTO>>(dbCar.Accounts);
                return Request.CreateResponse(HttpStatusCode.OK, obj);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // DELETE: api/Car/5
        [ResponseType(typeof(Car))]
        public IHttpActionResult DeleteCar(long id)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            db.Cars.Remove(car);
            db.SaveChanges();

            return Ok(car);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
        private bool CarExists(long id)
        {
            return db.Cars.Count(e => e.Id == id) > 0;
        }

        [Route("api/car/{accountId}/account")]
        public IHttpActionResult GetCarByAccountId(int accountId)
        {
            var ownerCars = db.Cars.Where(x => x.Accounts.Any(a => a.Id == accountId)).ToList();
            var selfCars = ownerCars.Where(x => x.Accounts.Count == 1).ToList();
            List<CarDTO> carDto = Mapper.Map<List<CarDTO>>(selfCars);
            if (carDto == null)
            {
                return NotFound();
            }

            return Ok(carDto);
        }
    }
}