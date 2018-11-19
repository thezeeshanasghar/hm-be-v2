using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HM_API_V4.Models.Custom
{
    public class TrasanctionWithSmsSatus : TransactionDTO
    {
        public string smsReponse { get; set; }
    }
}