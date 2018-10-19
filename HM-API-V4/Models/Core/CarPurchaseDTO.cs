using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HM_API_V4.Models.Core
{
    public class CarPurchaseDTO
    {
        public CarPurchaseDTO()
        {
            this.Buyers = new List<AccountDTO>();
            this.Sellers = new List<AccountDTO>();
            this.Witnesses = new List<WitnessDTO>();
        }

        public long Id { get; set; }
        public long CarID { get; set; }

        [JsonConverter(typeof(OnlyDateConverter))]
        public System.DateTime DealDate { get; set; }

        public decimal Price { get; set; }
        public decimal BuyerCom { get; set; }
        public decimal SellerCom { get; set; }

        public string Description { get; set; }
        public string DealType {get;set;}

        public virtual List<AccountDTO> Sellers { get; set; }
        public virtual List<AccountDTO> Buyers { get; set; }
        public virtual CarDTO Car { get; set; }
        public virtual List<WitnessDTO> Witnesses { get; set; }
    }
}