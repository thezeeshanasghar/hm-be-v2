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
        public long Buyer1ID { get; set; }
        public Nullable<long> Buyer2ID { get; set; }
        public long Seller1ID { get; set; }
        public Nullable<long> Seller2ID { get; set; }
        public Nullable<long> Witness1ID { get; set; }
        public Nullable<long> Witness2ID { get; set; }
        public System.DateTime DealDate { get; set; }
        public decimal Price { get; set; }
        public decimal BuyerCom { get; set; }
        public decimal SellerCom { get; set; }

        public virtual List<AccountDTO> Sellers { get; set; }
        public virtual List<AccountDTO> Buyers { get; set; }
        public virtual CarDTO Car { get; set; }
        public virtual List<WitnessDTO> Witnesses { get; set; }
    }
}