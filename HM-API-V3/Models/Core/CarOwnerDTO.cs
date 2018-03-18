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

        public virtual AccountDTO Account { get; set; }

        public virtual Car Car { get; set; }
    }
}