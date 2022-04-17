using System;
using System.Threading.Tasks;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.OrderDto;

namespace ProMusic.Helper.Interfaces
{
    public interface IOrderService
    {
        Task<OrderGetDto> CreateAsync(OrderDto orderDto);
        Task<OrderGetDto> GetByIdAsync(int id);
        Task<PagenatedListDto<OrderListItemDto>> GetAll(int page);
    }
}
