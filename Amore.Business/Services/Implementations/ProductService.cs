using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Category;
using Amore.Business.Helpers.DTOs.Product;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Interfaces;
using Amore.Core.Entities;
using Amore.DAL.Context;
using Amore.DAL.Repositories.Implementations;
using Amore.DAL.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Amore.Business.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IReadRepository<Product> _readRepository;
        private readonly IReadRepository<Tag> _tagRepository;
        private readonly IMapper _mapper;
        private readonly AmoreDbContext _context;

        public ProductService(IMapper mapper, IReadRepository<Product> readRepository, IProductRepository productRepository, IReadRepository<Tag> tagRepository, AmoreDbContext context)
        {
            _mapper = mapper;
            _readRepository = readRepository;
            _productRepository = productRepository;
            _tagRepository = tagRepository;
            _context = context;
        }

        public async Task<ICollection<GetProductDto>> GetAllAsync()
        {
            var products = await _readRepository.GetAllAsync(
                include: query => query
                    .Include(p => p.Category)
                    .Include(p => p.Tags).ThenInclude(t => t.Tag)
                    .Include(p => p.OrderProducts).ThenInclude(op => op.Order)
                    .Include(p => p.ProductVariants).ThenInclude(x => x.Variant)
            );

            return _mapper.Map<ICollection<GetProductDto>>(products);
        }

        public async Task<GetProductDto> GetByIdAsync(Guid id)
        {
            var product = await _readRepository.GetAllAsync(
                predicate: p => p.Id == id,
                include: query => query
                    .Include(p => p.Category)
                    .Include(p => p.Tags).ThenInclude(t => t.Tag)
                    .Include(p => p.OrderProducts).ThenInclude(op => op.Order)
                    .Include(p => p.ProductVariants).ThenInclude(x => x.Variant)
            );

            var result = product.FirstOrDefault();

            if (result == null) throw new ProductNotFoundException();

            return _mapper.Map<GetProductDto>(result);
        }


        public async Task<GetProductDto> CreateAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            var createdProduct = await _productRepository.CreateAsync(product);

            var tags = await _context.Tags
                .Where(tag => dto.TagIds.Contains(tag.Id))
                .ToListAsync();

            if (tags.Any())
            {
                createdProduct.Tags = new Collection<ProductTag>();
                foreach (Tag tag in tags)
                {
                    createdProduct.Tags.Add(new ProductTag()
                    {
                        TagId = tag.Id,
                        ProductId = createdProduct.Id
                    });
                }

                await _productRepository.UpdateAsync(createdProduct);
            }

            if (dto.VariantIds != null && dto.VariantIds.Any())
            {
                var variants = await _context.Variants
                    .Where(v => dto.VariantIds.Contains(v.Id))
                    .ToListAsync();

                if (variants.Any())
                {
                    if (createdProduct.ProductVariants == null)
                    {
                        createdProduct.ProductVariants = new Collection<ProductVariant>();
                    }
                    foreach (var variant in variants)
                    {
                        createdProduct.ProductVariants.Add(new ProductVariant()
                        {
                            ProductId = createdProduct.Id,
                            VariantId = variant.Id
                        });
                    }

                    await _productRepository.UpdateAsync(createdProduct);
                }
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<GetProductDto>(createdProduct);
        }



        public async Task UpdateAsync(UpdateProductDto dto)
        {
            var product  = await _readRepository.GetByIdAsync(dto.Id);
            if (product  == null) throw new ProductCannotBeUpdate();

            _mapper.Map(dto, product );
            await _productRepository.UpdateAsync(product );
        }

        public async Task RemoveAsync(Guid id)
        {
            var product  = await _readRepository.GetByIdAsync(id);
            if (product  == null)
            {
                throw new ProductNotFoundException();
            }
            await _productRepository.DeleteAsync(product );
        }
    }
}
//public async Task AddCategoryWithProductsAsync(CreateCategoryDto createCategoryDto)
//{
//    var category = _mapper.Map<Category>(createCategoryDto);
//    category.Id = Guid.NewGuid();

//    await _categoryWriteRepository.AddAsync(category);

//    foreach (var productId in createCategoryDto.ProductIds)
//    {
//        var existingProduct = await _productReadRepository.GetByIdAsync(productId);
//        if (existingProduct != null)
//        {
//            await _categoryProductWriteRepository.AddAsync(new CategoryProduct
//            {
//                CategoryId = category.Id,
//                ProductId = productId
//            });
//        }
//    }

//    await _categoryWriteRepository.SaveChangesAsync();

//    _cache.Remove("categories"); // Yeni ekleme olunca cache temizlenir
//}
//}