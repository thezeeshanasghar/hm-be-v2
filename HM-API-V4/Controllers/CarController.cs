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
using System.Web;
using Newtonsoft.Json;

namespace HM_API_V4.Controllers
{
    public class CarController : BaseController
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

        public Response<CarDTO> Post()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var model = HttpContext.Current.Request.Form.GetValues(0);
                string jsonContent = model[0];
                CarDTO carDTO = JsonConvert.DeserializeObject<CarDTO>(jsonContent);

                if (httpRequest.Files.Count > 0)
                {
                    int i = 0;
                    foreach (string file in httpRequest.Files)
                    {
                        i++;
                        var postedFile = httpRequest.Files[file];
                        var path = "UploadFile/" + DateTime.Now.Ticks + "-" + postedFile.FileName;
                        if (i == 1)
                        {
                            carDTO.Image1 = path;
                        }
                        else if (i == 2)
                        {
                            carDTO.Image2 = path;
                        }
                        var filePath = HttpContext.Current.Server.MapPath("~/" + path);
                        postedFile.SaveAs(filePath);
                    }
                }
                var dbCar = Mapper.Map<Car>(carDTO);
                dbCar.Accounts.Clear();
                db.Cars.Add(dbCar);
                db.SaveChanges();
                carDTO.Id = dbCar.Id;
                foreach (var account in carDTO.Accounts)
                {
                    Account dbAccount = db.Accounts.FirstOrDefault(s => s.Id == account.Id);
                    dbCar.Accounts.Add(dbAccount);
                    db.SaveChanges();
                }
                
                carDTO.Accounts = Mapper.Map<List<AccountDTO>>(dbCar.Accounts);
                return new Response<CarDTO>(true, null, carDTO);
            }
            catch (Exception e)
            {
                return new Response<CarDTO>(false, GetMessageFromExceptionObject(e), null);
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

        [Route("api/car/account/{accountId}")]
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

        [Route("api/car/account/{owner1Id}/{owner2Id}")]
        public IHttpActionResult GetSharedCars(int owner1Id, int owner2Id)
        {
            //var accountIds = db.Accounts.Where(x => x.Id == owner1Id && x.Id == owner2Id).Select(x => x.Id).ToList();
            var ownerCars = db.Cars.Where(x => (x.Accounts.Any(y => y.Id == owner1Id) && x.Accounts.Any(y => y.Id == owner2Id))).ToList();
            List<CarDTO> carDto = Mapper.Map<List<CarDTO>>(ownerCars);
            if (carDto == null)
            {
                return NotFound();
            }

            return Ok(carDto);
        }
    }
}