using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using ProMusic.Core;
using ProMusic.Core.Entities;
using ProMusic.Helper.DTOs;
using ProMusic.Helper.DTOs.SubCategoryDto;
using ProMusic.Helper.Exceptions;
using ProMusic.Helper.Interfaces;

namespace ProMusic.Helper.Implementations
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubCategoryService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _env = env;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Create

        public async Task<SubCategoryGetDto> CreateAsync(SubCategoryPostDto postDto)
        {
            if (await _unitOfWork.SubCategoryRepository
                .IsExist(x => x
                .Name
                .ToUpper()
                .Trim() == postDto
                .Name
                .ToUpper()
                .Trim())) throw new RecordDuplicatedException("Sub Category already exist");

            string fileName = "";
            if (postDto.Photo != null)
            {
                fileName = postDto.Photo.FileName;


                if (fileName.Length > 100)
                {
                    fileName = fileName.Substring(postDto.Photo.FileName.Length - 64, 64);
                }

                //string name = DateTime.Now.Second.ToString() + (fileName);

                string path = Path.Combine(_env.WebRootPath, "images/subcategories", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    postDto.Photo.CopyTo(stream);
                }

            }
            SubCategory category = _mapper.Map<SubCategory>(postDto);
            await _unitOfWork.SubCategoryRepository.AddAsync(category);
            await _unitOfWork.SaveAsync();
            return new SubCategoryGetDto
            {
                Id = category.Id,
                Name = category.Name,
                Image = category.Image,
                CategoryId = category.CategoryId
            };
        }

        #endregion

        #region Get

        public async Task<SubCategoryGetDto> GetByIdAsync(int id)
        {
            SubCategory category = await _unitOfWork.SubCategoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (category is null) throw new NotFoundException("Item not found");
            SubCategoryGetDto subCategoryGetDto = _mapper.Map<SubCategoryGetDto>(category);
            return subCategoryGetDto;
        }

        #endregion

        #region GetAll

        public async Task<PagenatedListDto<SubCategoryListItemDto>> GetAll(int page)
        {
            var query = _unitOfWork.SubCategoryRepository.GetAll(x => !x.IsDeleted);
            var pageSizeStr = await _unitOfWork.SettingRepository.GetValueAsync("PageSize");
            int pageSize = int.Parse(pageSizeStr);
            List<SubCategoryListItemDto> items = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new SubCategoryListItemDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image,
                    CategoryId = x.CategoryId,
                })
                .ToList();

            var listDto = new PagenatedListDto<SubCategoryListItemDto>(items, query.Count(), page, pageSize);
            return listDto;
        }

        #endregion

        #region Update

        public async Task UpdateAsync(int id, SubCategoryPostDto categoryPutDto)
        {
            SubCategory category = await _unitOfWork.SubCategoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (category is null) throw new NotFoundException("Item not found");

            SubCategory old = await _unitOfWork.SubCategoryRepository.GetAsync(x => x.Id == id);
            if (old is null) throw new NotFoundException("item not found");

            if (old.Image != null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "images/subcategories", old.Image);

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

                string path = Path.Combine(_env.WebRootPath, "images/subcategories", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    categoryPutDto.Photo.CopyTo(stream);
                }
            }

            if (await _unitOfWork.SubCategoryRepository.IsExist(x => x.Id != id && x.Name.ToUpper().Trim() == categoryPutDto.Name.ToUpper().Trim())) throw new RecordDuplicatedException("Sub Category already exist");
            category.Name = categoryPutDto.Name;
            category.Image = fileName;
            category.CategoryId = categoryPutDto.CategoryId;
            await _unitOfWork.SaveAsync();
        }

        #endregion

        #region Delete

        public async Task Delete(int id)
        {
            SubCategory category = await _unitOfWork.SubCategoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (category is null) throw new NotFoundException("Item not found");
            category.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        #endregion
    }
}
