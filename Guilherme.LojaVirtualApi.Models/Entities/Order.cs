using System;
using System.Collections.Generic;

namespace Guilherme.LojaVirtualApi.Models.Entities
{
    public class Order : BaseEntity
    {
        public DateTime Date { get; set; }
        public IEnumerable<OrderProduct> OrderProducts { get; set; }
    }
}
