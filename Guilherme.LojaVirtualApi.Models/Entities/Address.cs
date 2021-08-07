namespace Guilherme.LojaVirtualApi.Models.Entities
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Block { get; set; }
        public string ZipCode { get; set; }
        public Customer Customer { get; set; }
        public City City { get; set; }
    }
}
