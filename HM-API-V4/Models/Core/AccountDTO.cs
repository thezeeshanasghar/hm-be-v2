using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace HM_API_V4.Models
{
    public class AccountDTO
    {
        public AccountDTO()
        {
            this.Transactions = new HashSet<TransactionDTO>();
            this.Cars = new HashSet<CarDTO>();
        }
        public long Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Number { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        [Required]
        public string CNIC { get; set; }

        public string Address { get; set; }


        [JsonConverter(typeof(OnlyDateConverter))]
        public System.DateTime Created { get; set; }

        public decimal Balance { get; set; }

        public string Image { get; set; }

        [JsonIgnore]
        public virtual ICollection<TransactionDTO> Transactions { get; set; }

        [JsonIgnore]
        public virtual ICollection<CarDTO> Cars { get; set; }

    }
}