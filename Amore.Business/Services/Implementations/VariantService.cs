using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Variant;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Interfaces;
using Amore.Core.Entities;
using Amore.DAL.Repositories.Interfaces;
using AutoMapper;

namespace Amore.Business.Services.Implementations
{
    public class VariantService : IVariantService
    {
        private readonly IVariantRepository _variantRepository;
        private readonly IReadRepository<Variant> _readRepository;
        private readonly IMapper _mapper;

        public VariantService(IMapper mapper, IReadRepository<Variant> readRepository, IVariantRepository variantRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
            _variantRepository = variantRepository;
        }

        public async Task<IEnumerable<GetVariantDto>> GetAllAsync()
        {
            var varinat = await _readRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetVariantDto>>(varinat);
        }

        public async Task<GetVariantDto> GetByIdAsync(Guid Id)
        {
            var variant = await _readRepository.GetByIdAsync(Id);
            if (variant == null) throw new VariantNotFoundException();
            return _mapper.Map<GetVariantDto>(variant);
        }

        public async Task<GetVariantDto> CreateAsync(CreateVariantDto dto)
        {
            var variant = _mapper.Map<Variant>(dto);
            var newVariant = await _variantRepository.CreateAsync(variant);
            return _mapper.Map<GetVariantDto>(newVariant);
        }

        public async Task UpdateAsync(UpdateVariantDto dto)
        {
            var variant = await _readRepository.GetByIdAsync(dto.Id);
            if(variant == null) throw new VariantNotFoundException();
            await Task.Run(() => _mapper.Map<UpdateVariantDto>(variant));
            await _variantRepository.UpdateAsync(variant);

        }

        public async Task RemoveAsync(Guid Id)
        {
            var variant = await _readRepository.GetByIdAsync(Id);
            if(variant == null)
            {
                throw new VariantNotFoundException();
            }
            await _variantRepository.DeleteAsync(variant);
        }
    }
}
