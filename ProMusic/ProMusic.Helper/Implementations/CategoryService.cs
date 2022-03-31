using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using ProMusic.Core;
using ProMusic.Core.Entities;
using ProMusic.Core.Repositories;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.CategoryDto;
using ProMusic.Helper.Exceptions;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Helper.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _env = env;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Create

        public async Task<CategoryGetDto> CreateAsync(CategoryPostDto postDto)
        {
            if (await _unitOfWork.CategoryRepository.IsExist(x => x.Name.ToUpper().Trim() == postDto.Name.ToUpper().Trim())) throw new RecordDuplicatedException("Category already exist");
            string fileName = "";
            if (postDto.Photo != null)
            {
                fileName = postDto.Photo.FileName;


                if (fileName.Length > 100)
                {
                    fileName = fileName.Substring(postDto.Photo.FileName.Length - 64, 64);
                }

                //string name = DateTime.Now.Second.ToString() + (fileName);

                string path = Path.Combine(_env.WebRootPath, "images/categories", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    postDto.Photo.CopyTo(stream);
                }
            }
            Category category = _mapper.Map<Category>(postDto);
            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.SaveAsync();
            return new CategoryGetDto
            {
                Id = category.Id,
                Name = category.Name,
                Image = category.Image,
            };
        }

        #endregion
                
        #region Get

        public async Task<CategoryGetDto> GetByIdAsync(int id)
        {
            Category category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (category is null) throw new NotFoundException("Item not found");
            CategoryGetDto categoryGetDto = _mapper.Map<CategoryGetDto>(category);
            return categoryGetDto;
        }

        #endregion

        #region GetAll

        public async Task<PagenatedListDto<CategoryListItemDto>> GetAll(int page)
        {
            var query = _unitOfWork.CategoryRepository.GetAll(x => !x.IsDeleted);
            var pageSizeStr = await _unitOfWork.SettingRepository.GetValueAsync("PageSize");
            int pageSize = int.Parse(pageSizeStr);
            List<CategoryListItemDto> items = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new CategoryListItemDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image,
                })
                .ToList();

            var listDto = new PagenatedListDto<CategoryListItemDto>(items, query.Count(), page, pageSize);
            return listDto;
        }

        #endregion

        #region Update

        public async Task UpdateAsync(int id, CategoryPutDto categoryPutDto)
        {
            Category category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (category is null) throw new NotFoundException("Item not found");

            Category old = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id);
            if (old is null) throw new NotFoundException("item not found");

            if (old.Image != null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "images/categories", old.Image);

                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }
            }

            string fileName = "";
            if (categoryPutDto.Photo != null)
            {
                fileName = categoryPutDto.Photo.FileName;


                if (fileName.Length > 100)
                {
                    fileName = fileName.Substring(categoryPutDto.Photo.FileName.Length - 64, 64);
                }

                //string name = DateTime.Now.Second.ToString() + (fileName);

                string path = Path.Combine(_env.WebRootPath, "images/categories", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    categoryPutDto.Photo.CopyTo(stream);
                }
            }

            if (await _unitOfWork.CategoryRepository.IsExist(x => x.Id != id && x.Name.ToUpper().Trim() == categoryPutDto.Name.ToUpper().Trim())) throw new RecordDuplicatedException("Category already exist");
            category.Name = categoryPutDto.Name;
            category.Image = fileName;
            await _unitOfWork.SaveAsync();
        }

        #endregion

        #region Delete

        public async Task Delete(int id)
        {
            Category category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (category is null) throw new NotFoundException("Item not found");
            category.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        #endregion
    }
}
