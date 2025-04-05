using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Category;
using Amore.Business.Helpers.DTOs.Category;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Interfaces;
using Amore.Core.Entities;
using Amore.DAL.Repositories.Implementations;
using Amore.DAL.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amore.Business.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IReadRepository<Category> _readRepository;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository, IReadRepository<Category> readRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _readRepository = readRepository;
        }

        public async Task<IEnumerable<GetCategoryDto>> GetAllAsync()
        {
            var categories = await _readRepository.GetAllAsync(
                include: query => query.Include(c => c.Products));

            return _mapper.Map<IEnumerable<GetCategoryDto>>(categories);

        }

        public async Task<GetCategoryDto> GetByIdAsync(Guid id)
        {
            var category = await _readRepository.GetAllAsync(
                predicate: c => c.Id == id,
                include: query => query.Include(c => c.Products) 
            );

            var result = category.FirstOrDefault();
            if (result == null)
                throw new CategoryNotFoundException();

            return _mapper.Map<GetCategoryDto>(result);
        }


        public async Task<GetCategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto), "Dto error verir");
            var category = _mapper.Map<Category>(dto);
            var categorynew = await _categoryRepository.CreateAsync(category);
            return _mapper.Map<GetCategoryDto>(categorynew);

        }

        public async Task UpdateAsync(UpdateCategoryDto dto)
        {
            var category = await _readRepository.GetByIdAsync(dto.Id);
            if (category == null) throw new CategoryCannotBeUpdate();

            _mapper.Map(dto, category);
            await _categoryRepository.UpdateAsync(category);
        }

        public async Task RemoveAsync(Guid id)
        {
            var category = await _readRepository.GetByIdAsync(id);
            if (category == null)
            {
                throw new CategoryNotFoundException();
            }
            await _categoryRepository.DeleteAsync(category);
        }
    }
}
