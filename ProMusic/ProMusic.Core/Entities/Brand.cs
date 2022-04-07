using System;
using System.Collections.Generic;

namespace ProMusic.Core.Entities
{
    public class Brand:BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Desc { get; set; }
        public List<Product> Products { get; set; }
    }
}
