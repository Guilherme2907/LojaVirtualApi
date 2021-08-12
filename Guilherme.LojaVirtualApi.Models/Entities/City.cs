using Newtonsoft.Json;

namespace Guilherme.LojaVirtualApi.Models.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public virtual State State { get; set; }
        public long StateId { get; set; }
    }
}
