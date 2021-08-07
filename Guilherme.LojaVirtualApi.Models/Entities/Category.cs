﻿using System.Collections.Generic;

namespace Guilherme.LojaVirtualApi.Models.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<Product> Products{ get; set; }
    }
}
