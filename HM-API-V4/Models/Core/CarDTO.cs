using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HM_API_V4.Models
{
    public class CarDTO
    {
        public CarDTO()
        {
            this.Accounts = new HashSet<AccountDTO>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string EngineNumber { get; set; }
        public string ModelNumber { get; set; }
        public string ChasisNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public string Maker { get; set; }
        public string Token { get; set; }
        public bool ComputerizedNoPlate { get; set; }
        public int? NoOfPapers { get; set; }
        public decimal PurchasePrice { get; set; }
        public System.DateTime PurchaseDate { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string ReceiptNumber { get; set; }
        public virtual ICollection<AccountDTO> Accounts { get; set; }
        public  List<AccountDTO> Owners { get; set; }


    }
}