using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Product;
using Amore.Business.Helpers.DTOs.Tag;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Interfaces;
using Amore.Core.Entities;
using Amore.DAL.Repositories.Implementations;
using Amore.DAL.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Amore.Business.Services.Implementations
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IReadRepository<Tag> _readRepository;
        private readonly IMapper _mapper;

        public TagService(IMapper mapper, IReadRepository<Tag> readRepository, ITagRepository tagRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
            _tagRepository = tagRepository;
        }

        public async Task<IEnumerable<GetTagDto>> GetAllAsync()
        {
            var tags = await _readRepository.GetAllAsync(include: query => query
            .Include(p => p.Products).ThenInclude(x=>x.Product));
            return _mapper.Map<IEnumerable<GetTagDto>>(tags);
        }

        public async Task<GetTagDto> GetByIdAsync(Guid id)
        {
            var tag = await _readRepository.GetAllAsync(
                include: query => query.Include(c => c.Products).ThenInclude(x => x.Product));

            var result = tag.FirstOrDefault();

            if (result == null)
                throw new TagNotFoundException();

            return _mapper.Map<GetTagDto>(result);
        }

        public async Task<GetTagDto> CreateAsync(CreateTagDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto), "Dto error verir");
            var tag = _mapper.Map<Tag>(dto);
            var tagnew = await _tagRepository.CreateAsync(tag);
            return _mapper.Map<GetTagDto>(tagnew);
        }

        public async Task UpdateAsync(UpdateTagDto dto)
        {
            var tag = await _readRepository.GetByIdAsync(dto.Id);
            if (tag == null) throw new TagCannotBeUpdate();

            _mapper.Map(dto, tag);
            await _tagRepository.UpdateAsync(tag);
        }

        public async Task RemoveAsync(Guid id)
        {
            var tag = await _readRepository.GetByIdAsync(id);
            if (tag == null)
            {
                throw new Exception("Slayder Tapilmadi.");
            }
            await _tagRepository.DeleteAsync(tag);
        }
    }
}
