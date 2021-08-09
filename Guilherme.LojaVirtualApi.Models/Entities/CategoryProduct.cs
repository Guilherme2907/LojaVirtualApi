using Guilherme.LojaVirtualApi.Models.Entities.Enums;
using System.Collections.Generic;

namespace Guilherme.LojaVirtualApi.Models.Entities
{
    public class CategoryProduct : BaseEntity
    {
        public Product Product { get; set; }
        public long ProductId { get; set; }
        public Category Category { get; set; }
        public long CategoryId { get; set; }
    }
}
