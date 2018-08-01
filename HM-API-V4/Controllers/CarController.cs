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

        // GET: api/Car
        public IQueryable<Car> GetCars()
        {
            return db.Cars;
        }

        // GET: api/Car/5
        [ResponseType(typeof(Car))]
        public IHttpActionResult GetCar(long id)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
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
                    Account dbAccount = db.Accounts.FirstOrDefault(s => s.Id == account.Id);
                    dbCar.Accounts.Add(dbAccount);
                } 
                db.Cars.Add(dbCar);
                db.SaveChanges();
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

        private bool CarExists(long id)
        {
            return db.Cars.Count(e => e.Id == id) > 0;
        }
    }
}