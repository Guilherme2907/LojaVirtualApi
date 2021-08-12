using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Guilherme.LojaVirtualApi.Models.Entities
{
    public class Order : BaseEntity
    {
        public DateTime Date { get; set; }
        public virtual Address DeliveryAddress { get; set; }
        [JsonIgnore]
        public long DeliveryAddressId { get; set; }
        public virtual Payment Payment { get; set; }
        [JsonIgnore]
        public long PaymentId { get; set; }
        public virtual Customer Customer { get; set; }
        [JsonIgnore]
        public long CustomerId { get; set; }
        public virtual ICollection<OrderItem> Items { get; set; }
    }
}
