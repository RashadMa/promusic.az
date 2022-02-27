using System;
using System.Collections.Generic;

namespace ProMusic.Helper.DTOs
{
    public class ListDto<T>
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
