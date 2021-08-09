namespace Guilherme.LojaVirtualApi.Models.Entities
{
    public class OrderProduct : BaseEntity
    {
        public double Discount { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Order Order { get; set; }
        public long OrderId { get; set; }
        public Product Product { get; set; }
        public long ProductId { get; set; }

    }
}
