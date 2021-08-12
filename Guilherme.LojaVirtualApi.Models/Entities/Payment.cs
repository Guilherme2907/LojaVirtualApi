using Guilherme.LojaVirtualApi.Models.Entities.Enums;
using Newtonsoft.Json;

namespace Guilherme.LojaVirtualApi.Models.Entities
{
    public class Payment : BaseEntity
    {
        public PaymentStatus PaymentStatus { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }
        [JsonIgnore]
        public long OrderId { get; set; }
    }
}
