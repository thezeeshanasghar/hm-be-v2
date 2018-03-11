using AutoMapper;
using HM_API_V3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.IO;
using System.Net.Http.Headers;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using System.Web.Hosting;
using System.Diagnostics;

namespace HM_API_V3.Controllers
{
    public class CarController : BaseController
    {
        #region C R U D

        public Response<IEnumerable<CarDTO>> Get()
        {
            try
            {
                using (HMEntities1 entities = new HMEntities1())
                {
                    var dbCars = entities.Cars.ToList();
                    IEnumerable<CarDTO> CarDTOs = Mapper.Map<IEnumerable<CarDTO>>(dbCars);
                    return new Response<IEnumerable<CarDTO>>(true, null, CarDTOs);
                }
            }
            catch (Exception e)
            {
                return new Response<IEnumerable<CarDTO>>(false, GetMessageFromExceptionObject(e), null);
            }
        }

        public Response<CarDTO> Get(int Id)
        {
            try
            {
                using (HMEntities1 entities = new HMEntities1())
                {
                    var dbCars = entities.Cars.Where(c => c.Id == Id).FirstOrDefault();
                    CarDTO CarDTO = Mapper.Map<CarDTO>(dbCars);
                    return new Response<CarDTO>(true, null, CarDTO);
                }
            }
            catch (Exception e)
            {
                return new Response<CarDTO>(false, GetMessageFromExceptionObject(e), null);
            }

        }

        public Response<CarDTO> Post()
        {
            var httpRequest = HttpContext.Current.Request;

            var model  = HttpContext.Current.Request.Form.GetValues(0);
            string jsonContent = model[0];
            CarDTO CarDTO = JsonConvert.DeserializeObject<CarDTO>(jsonContent);

            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var path = "UploadFile/" + DateTime.Now.Ticks + postedFile.FileName;
                    CarDTO.Image1 = path;
                    var filePath = HttpContext.Current.Server.MapPath("~/" + path);
                    postedFile.SaveAs(filePath);
                }
            }
            else
                CarDTO.Image1 = "UploadFile/no-image.png";
            try
            {

                using (HMEntities1 entities = new HMEntities1())
                {
                    Car CarDB = Mapper.Map<Car>(CarDTO);
                    entities.Cars.Add(CarDB);
                    entities.SaveChanges();

                    CarDB = entities.Cars.Where(x => x.Id == CarDB.Id).FirstOrDefault();
                    CarDTO.Id = CarDB.Id;

                    return new Response<CarDTO>(true, null, CarDTO);
                }
            }
            catch (Exception e)
            {
                return new Response<CarDTO>(false, GetMessageFromExceptionObject(e), null);
            }
        }
        public Response<CarDTO> Put(int Id, CarDTO CarDTO)
        {
            try
            {
                using (HMEntities1 entities = new HMEntities1())
                {
                    var dbCar = entities.Cars.Where(c => c.Id == Id).FirstOrDefault();
                    if (dbCar == null)
                        return new Response<CarDTO>(false, "Car not found", null);
                    dbCar = Mapper.Map<CarDTO, Car>(CarDTO, dbCar);
                    entities.SaveChanges();
                    return new Response<CarDTO>(true, null, CarDTO);
                }
            }
            catch (Exception e)
            {
                return new Response<CarDTO>(false, GetMessageFromExceptionObject(e), null);
            }
        }

        public Response<string> Delete(int Id)
        {
            try
            {
                using (HMEntities1 entities = new HMEntities1())
                {
                    var dbVaccine = entities.Cars.Where(c => c.Id == Id).FirstOrDefault();
                    entities.Cars.Remove(dbVaccine);
                    entities.SaveChanges();
                    return new Response<string>(true, null, "record deleted");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                    return new Response<string>(false, "Cannot delete Car because related record exists in database.", null);
                else
                    return new Response<string>(false, GetMessageFromExceptionObject(ex), null);
            }
        }

        #endregion


     
        

    }
}
