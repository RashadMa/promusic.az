using System;
using System.Threading.Tasks;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.CommentDto;

namespace ProMusic.Helper.Interfaces
{
    public interface ICommentService
    {
        Task<CommentGetDto> CreateAsync(CommentPostDto postDto);
        Task<CommentGetDto> GetByIdAsync(int id);
        Task<PagenatedListDto<CommentGetAllDto>> GetAll(int page);
    }
}
