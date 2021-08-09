using System.Collections.Generic;

namespace Guilherme.LojaVirtualApi.Models.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<CategoryProduct> CategoryProducts { get; set; }
    }
}
