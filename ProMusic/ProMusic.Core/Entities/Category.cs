using System;
using System.Collections.Generic;

namespace ProMusic.Core.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public bool IsSubCategory { get; set; }
        public List<Product> Products { get; set; }
    }
}
