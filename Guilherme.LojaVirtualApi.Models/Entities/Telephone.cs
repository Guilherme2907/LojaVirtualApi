using Newtonsoft.Json;

namespace Guilherme.LojaVirtualApi.Models.Entities
{
    public class Telephone : BaseEntity
    {
        public string Number { get; set; }
        [JsonIgnore]
        public long CustomerId { get; set; }
    }          
}
