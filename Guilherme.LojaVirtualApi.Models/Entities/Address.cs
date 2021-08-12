using Newtonsoft.Json;

namespace Guilherme.LojaVirtualApi.Models.Entities
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Block { get; set; }
        public string ZipCode { get; set; }
        [JsonIgnore]
        public virtual Customer Customer { get; set; }
        [JsonIgnore]
        public long CustomerId { get; set; }
        public virtual City City { get; set; }
        [JsonIgnore]
        public long CityId { get; set; }
    }
}
