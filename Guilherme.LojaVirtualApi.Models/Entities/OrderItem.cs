using Newtonsoft.Json;

namespace Guilherme.LojaVirtualApi.Models.Entities
{
    public class OrderItem
    {
        public double Discount { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }
        [JsonIgnore]
        public long OrderId { get; set; }
        public virtual Product Product { get; set; }
        [JsonIgnore]
        public long ProductId { get; set; }

    }
}
