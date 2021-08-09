using System;
using System.Collections.Generic;

namespace Guilherme.LojaVirtualApi.Models.Entities
{
    public class Order : BaseEntity
    {
        public DateTime Date { get; set; }
        public Address DeliveryAddress { get; set; }
        public long DeliveryAddressId { get; set; }
        public IEnumerable<OrderProduct> OrderProducts { get; set; }
        public Payment Payment { get; set; }
        public Customer Customer { get; set; }
        public long CustomerId { get; set; }
    }
}
