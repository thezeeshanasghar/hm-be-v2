using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HM_API_V3.Models
{
    public class CarOwnerDTO
    {
        public long Id { get; set; }

        public long CarID { get; set; }

        public long AccountID { get; set; }

        [JsonIgnore]
        public virtual AccountDTO Account { get; set; }

        [JsonIgnore]
        public virtual Car Car { get; set; }
    }
}