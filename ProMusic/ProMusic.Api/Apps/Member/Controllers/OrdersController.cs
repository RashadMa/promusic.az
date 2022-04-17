using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProMusic.Core;
using ProMusic.Core.Entities;
using ProMusic.Helper.DTOs.OrderDto;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Api.Apps.Member.Controllers
{
    [Route("member/api/[controller]"), ApiController]
    public class OrdersController : Controller
    {

        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService, IMapper mapper, UserManager<AppUser> userManager, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _orderService = orderService;
            _userManager = userManager;
        }


        #region Create

        [HttpPost("")]
        public async Task<IActionResult> Create(OrderDto orderDto)
        {
            var order = await _orderService.CreateAsync(orderDto);
            return StatusCode(201, order);
        }

        #endregion

        #region Get

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _orderService.GetByIdAsync(id));
        }

        #endregion

        #region GetAll

        [HttpGet("")]
        public async Task<IActionResult> GetAll(int page = 1)
        {
            return Ok(await _orderService.GetAll(page));
        }

        #endregion



        //[HttpPost("")]
        //public IActionResult Test(OrderDto order)
        //{
        //    return Ok(order);
        //}

        //[HttpPost("eben")]
        //public IActionResult Create(OrderDto orderDto)
        //{
        //    var user = _userManager.Users.FirstOrDefault(x => x.UserName == orderDto.Order.AppUserId && !x.IsAdmin);
        //    Order order = _mapper.Map<Order>(orderDto.Order);

        //    order.AppUserId = user.Id;
        //    order.CratedAt = DateTime.UtcNow.AddHours(4);
        //    order.ModifiedAt = DateTime.UtcNow.AddHours(4);
        //    order.Status = Core.Enums.OrderStatus.Pending;
        //    order.OrderItems = new List<OrderItem>();


        //    foreach (var item in orderDto.Products)
        //    {
        //        OrderItem orderItem = new OrderItem
        //        {
        //            Count = orderDto.Products.Count,
        //            ProductId = item.Id,
        //            SalePrice = item.SalePrice,
        //            CostPrice = item.CostPrice,
        //            DiscountedPrice = item.DiscountPercent > 0 ? (item.SalePrice * (1 - item.DiscountPercent / 100)) : item.SalePrice,
        //        };

        //        orderDto.Count = orderDto.Products.Count * orderDto.Count;
        //        order.OrderItems.Add(orderItem);
        //        order.TotalPrice += orderItem.DiscountedPrice * orderDto.Count;

        //    }

        //    _unitOfWork.OrderRepository.AddAsync(order);
        //    _unitOfWork.SaveAsync();
        //    return Ok(user);
        //}
    }
}
