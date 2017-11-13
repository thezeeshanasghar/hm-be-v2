﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HM_API_V3.Models
{
    public class AccountDTO
    {
        public AccountDTO()
        {
            this.Transactions = new HashSet<Transaction>();
        }
        public long Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string CNIC { get; set; }
        public string Address { get; set; }
        public System.DateTime Created { get; set; }
        public decimal Balance { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}