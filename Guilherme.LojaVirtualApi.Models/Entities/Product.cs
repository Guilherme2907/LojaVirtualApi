using Newtonsoft.Json;
using System.Collections.Generic;

namespace Guilherme.LojaVirtualApi.Models.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        [JsonIgnore]
        public virtual ICollection<Category> Categories { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderItem> Items { get; set; }
    }
}
