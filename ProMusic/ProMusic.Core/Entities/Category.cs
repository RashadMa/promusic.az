using System;
using System.Collections.Generic;

namespace ProMusic.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public bool IsSubCategory { get; set; }
        public int? CategoryId { get; set; }
        public List<Product> Products { get; set; }
    }
}
