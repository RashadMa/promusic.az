using System;
using System.Collections.Generic;

namespace ProMusic.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
