using Guilherme.LojaVirtualApi.Models.Entities.Enums;

namespace Guilherme.LojaVirtualApi.Models.Entities
{
    public class Payment : BaseEntity
    {
        public PaymentStatus PaymentStatus { get; set; }

        public Order Order { get; set; }
        public long OrderId { get; set; }
    }
}
