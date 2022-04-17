using System;
using System.Collections.Generic;
using ProMusic.Helper.DTOs.ProductDto;

namespace ProMusic.Helper.DTOs.OrderDto
{
    public class OrderDto
    {
        public List<ProductGetDto> Products{ get; set; }
        public OrderPostDto Order { get; set; }
        public int Count { get; set; }
    }
}
