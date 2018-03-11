using HM_API_V3.App_Code;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;

namespace HM_API_V3.Models
{
    public class AccountDTO
    {
        public long Id { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }

        public string MobileNumber { get; set; }

        public string CNIC { get; set; }

        public string Address { get; set; }

        public string Image { get; set; }

        [JsonConverter(typeof(OnlyDateConverter))]
        public System.DateTime Created { get; set; }

        public decimal Balance { get; set; }
        
    }
}