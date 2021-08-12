using System.Collections.Generic;

namespace Guilherme.LojaVirtualApi.Models.Entities
{
    public class State : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
