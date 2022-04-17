using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProMusic.Core;
using ProMusic.Core.Entities;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.OrderDto;
using ProMusic.Helper.Exceptions;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Helper.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }


        public async Task<OrderGetDto> CreateAsync(OrderDto orderDto)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.UserName == orderDto.Order.AppUserId && !x.IsAdmin);
            Order order = _mapper.Map<Order>(orderDto.Order);

            order.AppUserId = user.Id;
            order.CratedAt = DateTime.UtcNow.AddHours(4);
            order.ModifiedAt = DateTime.UtcNow.AddHours(4);
            order.Status = Core.Enums.OrderStatus.Pending;
            order.OrderItems = new List<OrderItem>();


            foreach (var item in orderDto.Products)
            {
                OrderItem orderItem = new OrderItem
                {
                    Count = orderDto.Products.Count,
                    ProductId = item.Id,
                    SalePrice = item.SalePrice,
                    CostPrice = item.CostPrice,
                    DiscountedPrice = item.DiscountPercent > 0 ? (item.SalePrice * (1 - item.DiscountPercent / 100)) : item.SalePrice,
                };

                orderDto.Count = orderDto.Products.Count * orderDto.Count;
                order.OrderItems.Add(orderItem);
                order.TotalPrice += orderItem.DiscountedPrice * orderDto.Count;

            }

            await _unitOfWork.OrderRepository.AddAsync(order);
            await _unitOfWork.SaveAsync();
            return new OrderGetDto
            {
                Status = order.Status,
                AppUserId = order.AppUserId,
                Email = order.Email,
                Adress = order.Adress,
                Phone = order.Phone,
                TotalPrice = order.TotalPrice,
            };
        }

        #region GetAll

        public async Task<PagenatedListDto<OrderListItemDto>> GetAll(int page)
        {
            var query = _unitOfWork.OrderRepository.GetAll(x => !x.IsDeleted);
            var pageSizeStr = await _unitOfWork.SettingRepository.GetValueAsync("PageSize");
            int pageSize = int.Parse(pageSizeStr);
            List<OrderListItemDto> items = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new OrderListItemDto
                {
                    Id = x.Id,
                    Status = x.Status,
                    AppUserId = x.AppUserId,
                    Email = x.Email,
                    Adress = x.Adress,
                    Phone = x.Phone,
                    TotalPrice = x.TotalPrice
                })
                .ToList();

            var listDto = new PagenatedListDto<OrderListItemDto>(items, query.Count(), page, pageSize);
            return listDto;
        }

        #endregion


        #region Get

        public async Task<OrderGetDto> GetByIdAsync(int id)
        {
            Order order = await _unitOfWork.OrderRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (order is null) throw new NotFoundException("Item not found");
            OrderGetDto orderGetDto = _mapper.Map<OrderGetDto>(order);
            return orderGetDto;
        }

        #endregion
    }
}
