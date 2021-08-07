﻿using System.Collections.Generic;

namespace Guilherme.LojaVirtualApi.Models.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<OrderProduct> OrderProducts { get; set; }
    }
}