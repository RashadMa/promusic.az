using System;
using System.Collections.Generic;

namespace ProMusic.Core.Entities
{
    public class SubCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Product> Products { get; set; }
    }
}
