namespace Guilherme.LojaVirtualApi.Models.Entities
{
    public class Telephone : BaseEntity
    {
        public string Number { get; set; }
        public long CustomerId { get; set; }
    }          
}
