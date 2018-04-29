using AutoMapper;
using HM_API_V3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Data.Entity.Validation;

namespace HM_API_V3.Controllers
{
    public class CarController : BaseController
    {
        #region C R U D
        public Response<IEnumerable<CarInventoryResponseDTO>> Get()
        {
            var list = new List<CarInventoryResponseDTO>();
            using (HMEntities1 entities = new HMEntities1())
            {
                var cars = entities.Cars.ToList();
                foreach (var car in cars)
                {
                    var single = new CarInventoryResponseDTO();
                    single.CarDTO = Mapper.Map<CarDTO>(car);
                    single.CarOwnerDTOs = new List<CarOwnerDTO>();

                    var carOwners = car.CarOwners.ToList();
                    foreach (var carOwner in carOwners)
                        single.CarOwnerDTOs.Add(Mapper.Map<CarOwnerDTO>(carOwner));
                    list.Add(single);
                }
            }
            return new Response<IEnumerable<CarInventoryResponseDTO>>(true, null, list);
        }


        public Response<CarInventoryResponseDTO> Post()
        {
            var httpRequest = HttpContext.Current.Request;

            var model = HttpContext.Current.Request.Form.GetValues(0);
            string jsonContent = model[0];
            CarInventoryResponseDTO carInventoryResponseDTO = JsonConvert.DeserializeObject<CarInventoryResponseDTO>(jsonContent);

            if (httpRequest.Files.Count > 0)
            {

                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var path = "UploadFile/" + DateTime.Now.Ticks + postedFile.FileName;
                    carInventoryResponseDTO.CarDTO.Image1 = path; // apply science for Image2
                    var filePath = HttpContext.Current.Server.MapPath("~/" + path);
                    postedFile.SaveAs(filePath);
                }
            }
            else
                carInventoryResponseDTO.CarDTO.Image1 = "UploadFile/no-image.png";
            try
            {

                using (HMEntities1 entities = new HMEntities1())
                {
                    Car CarDB = Mapper.Map<Car>(carInventoryResponseDTO.CarDTO);
                    entities.Cars.Add(CarDB);
                    entities.SaveChanges();

                    carInventoryResponseDTO.CarDTO.Id = CarDB.Id;
                    foreach (var co in carInventoryResponseDTO.CarOwnerDTOs)
                    {
                        CarOwner coDB = Mapper.Map<CarOwner>(co);
                        coDB.Car = CarDB;
                        coDB.CarID = co.Id = CarDB.Id;
                        entities.CarOwners.Add(coDB);
                        entities.SaveChanges();
                        co.CarID = CarDB.Id;
                        co.Id = coDB.Id;
                    }
                    return new Response<CarInventoryResponseDTO>(true, null, carInventoryResponseDTO);
                }
            }
            catch (DbEntityValidationException e)
            {
                string message = String.Empty;
                foreach (var eve in e.EntityValidationErrors)
                {

                    message = String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                       eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        message += String.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                return new Response<CarInventoryResponseDTO>(false, message, null); ;
            }
            catch (Exception e)
            {
                return new Response<CarInventoryResponseDTO>(false, GetMessageFromExceptionObject(e), null);
            }
        }

        #endregion





    }
}
