using System;
using System.Collections.Generic;
using ProMusic.Core.Enums;

namespace ProMusic.Core.Entities
{
    public class Order : BaseEntity
    {
        public OrderStatus Status { get; set; }
        public string AppUserId { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public decimal TotalPrice { get; set; }
        public AppUser AppUser { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
