using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HM_API_V3.Models
{
    public class CarDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string EngineNumber { get; set; }
        public string ModelNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public string Maker { get; set; }
        public string Token { get; set; }
        public bool ComputerizedNoPlate { get; set; }
        public int? NoOfPapers { get; set; }
        public decimal? SellPrice { get; set; }
        public DateTime SellDate { get; set; }
        public decimal? AdvanceAmount { get; set; }
        public decimal? RemainingAmount { get; set; }
        public DateTime DueDateOfRemainingAmount { get; set; }
        public decimal? PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Status { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }

        public virtual ICollection<CarAccount> CarAccounts { get; set; }
    }
}