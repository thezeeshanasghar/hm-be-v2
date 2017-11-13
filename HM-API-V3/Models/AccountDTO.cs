using System.Collections.Generic;

namespace HM_API_V3.Models
{
    public class AccountDTO
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string CNIC { get; set; }
        public string Address { get; set; }

        //[JsonConverter(typeof(OnlyDateConverter))]
        public System.DateTime Created { get; set; }
        public decimal Balance { get; set; }
        
    }
}