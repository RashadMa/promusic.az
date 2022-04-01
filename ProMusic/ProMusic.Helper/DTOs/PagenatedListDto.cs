using System;
using System.Collections.Generic;
using System.Linq;

namespace ProMusic.Helper.DTOs
{
    public class PagenatedListDto<TItem>
    {
        public PagenatedListDto(List<TItem> items, int count, int pageIndex, int pageSize)
        {
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            this.Items.AddRange(items);
            this.PageIndex = pageIndex;
        }
        public List<TItem> Items { get; set; } = new List<TItem>();
        public int TotalPage { get; set; }
        public int PageIndex { get; set; }
        public bool HasNext { get => PageIndex < TotalPage; }
        public bool HasPrev { get => PageIndex > 1; }
    }
}
