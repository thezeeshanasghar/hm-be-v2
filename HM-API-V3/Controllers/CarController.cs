using AutoMapper;
using HM_API_V3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace HM_API_V3.Controllers
{
    public class CarController : BaseController
    {
        #region C R U D

        

        public Response<CarDTO> Post()
        {
            var httpRequest = HttpContext.Current.Request;

            var model  = HttpContext.Current.Request.Form.GetValues(0);
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

                    CarDB = entities.Cars.Where(x => x.Id == CarDB.Id).FirstOrDefault();
                    carInventoryResponseDTO.CarDTO.Id = CarDB.Id;

                    return new Response<CarDTO>(true, null, carInventoryResponseDTO.CarDTO);
                }
            }
            catch (Exception e)
            {
                return new Response<CarDTO>(false, GetMessageFromExceptionObject(e), null);
            }
        }
     
        #endregion


     
        

    }
}
