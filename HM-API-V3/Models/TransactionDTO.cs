using HM_API_V3.App_Code;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HM_API_V3.Models
{
    public class TransactionDTO
    {
        public long Id { get; set; }
        public string Number { get; set; }

        [JsonConverter(typeof(OnlyDateConverter))]
        public System.DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public long AccountID { get; set; }

        //public virtual Account Account { get; set; }
    }
}