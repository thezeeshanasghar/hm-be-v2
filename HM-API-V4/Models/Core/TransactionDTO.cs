using Newtonsoft.Json;

namespace HM_API_V4.Models
{
    public class TransactionDTO
    {
        public long Id { get; set; }

        public string Number { get; set; }

        [JsonConverter(typeof(OnlyDateConverter))]
        public System.DateTime Date { get; set; }

        public decimal Amount { get; set; }
        public string Description { get; set; }

        public long AccountID { get; set; }

        [JsonIgnore]
        public virtual Account Account { get; set; }
    }
}