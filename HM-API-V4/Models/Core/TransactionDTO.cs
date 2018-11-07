using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HM_API_V4.Models
{
    public class TransactionDTO
    {
        public long Id { get; set; }

        public string Number { get; set; }

        [JsonConverter(typeof(IsoDateTimeConverter))]
        public System.DateTime Date { get; set; }

        public decimal Amount { get; set; }
        public string Description { get; set; }

        public long AccountID { get; set; }

        [JsonIgnore]
        public virtual Account Account { get; set; }
    }
}