﻿using System.Collections.Generic;

namespace HM_API_V4.Models
{
    public class TransactionWithPreviousBalanceDTO
    {
        public decimal PreviousBalance { get; set; }

        public List<TransactionDTO> Transactions;
        
    }
}