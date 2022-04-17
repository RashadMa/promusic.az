using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProMusic.Core;
using ProMusic.Core.Entities;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.AccountDto;
using ProMusic.Helper.DTOs.CommentDto;
using ProMusic.Helper.DTOs.ProductDto;
using ProMusic.Helper.Exceptions;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Helper.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Create

        public async Task<CommentGetDto> CreateAsync(CommentPostDto postDto)
        {
            
            Comment comment = _mapper.Map<Comment>(postDto);

            await _unitOfWork.CommentRepository.AddAsync(comment);
            await _unitOfWork.SaveAsync();
            return new CommentGetDto
            {
                Id = comment.Id,
                Text = comment.Text,
                Rate = comment.Rate,
                AppUserId = comment.AppUserId,
                ProductId = comment.ProductId,
            };
        }

        #endregion

        #region Get

        public async Task<CommentGetDto> GetByIdAsync(int id)
        {
            Comment comment = await _unitOfWork.CommentRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (comment is null) throw new NotFoundException("Item not found");
            CommentGetDto commentGetDto = _mapper.Map<CommentGetDto>(comment);
            return commentGetDto;
        }

        #endregion

        #region GetAll

        public async Task<PagenatedListDto<CommentGetAllDto>> GetAll(int page)
        {
            var query = _unitOfWork.CommentRepository.GetAll(x => !x.IsDeleted);
            var pageSizeStr = await _unitOfWork.SettingRepository.GetValueAsync("PageSize");
            int pageSize = int.Parse(pageSizeStr);

            List<CommentGetAllDto> items = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new CommentGetAllDto
                {
                    Id = x.Id,
                    Text = x.Text,
                    Rate = x.Rate,
                    AppUserId = x.AppUserId,
                    ProductId = x.ProductId,
                    Product = _mapper.Map<ProductGetDto>(x.Product),
                })
                .ToList();

            var listDto = new PagenatedListDto<CommentGetAllDto>(items, query.Count(), page, pageSize);
            return listDto;
        }

        #endregion       
    }
}
