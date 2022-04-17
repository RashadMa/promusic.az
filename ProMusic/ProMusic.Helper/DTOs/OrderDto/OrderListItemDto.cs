using System;
using ProMusic.Core.Enums;

namespace ProMusic.Helper.DTOs.OrderDto
{
    public class OrderListItemDto
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public string AppUserId { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
