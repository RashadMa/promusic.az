using System;
using System.Collections.Generic;
using ProMusic.Core.Entities;
using ProMusic.Core.Enums;

namespace ProMusic.Helper.DTOs.OrderDto
{
    public class OrderGetDto
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
