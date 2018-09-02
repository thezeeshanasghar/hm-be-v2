using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HM_API_V4.Models.Core
{
    public class WitnessDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CNIC { get; set; }
        public string Contact { get; set; }
        public string Image { get; set; }

    }
}