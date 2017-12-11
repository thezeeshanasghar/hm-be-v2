using HM_API_V3.App_Code;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HM_API_V3.Models
{
    public class TransactionWithPreviousBalanceDTO
    {
        public decimal PreviousBalance { get; set; }

        public List<TransactionDTO> Transactions;
        
    }
}