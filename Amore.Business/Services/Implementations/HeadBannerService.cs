using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.HeadBanner;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Interfaces;
using Amore.Core.Entities;
using Amore.DAL.Repositories.Interfaces;
using AutoMapper;

namespace Amore.Business.Services.Implementations
{
    public class HeadBannerService : IHeadBannerService
    {
        private readonly IMapper _mapper;
        private readonly IWriteRepository<HeadBanner> _repository;
        private readonly IReadRepository<HeadBanner> _readRepository;

           public HeadBannerService(IMapper mapper, IWriteRepository<HeadBanner> repository, IReadRepository<HeadBanner> readRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _readRepository = readRepository;
        }
        public async Task<IEnumerable<GetHeadBannerDto>> GetAllAsync()
        {
            var banner = await _readRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetHeadBannerDto>>(banner);

        }

        public async Task<GetHeadBannerDto> GetById(Guid id)
        {
            var banner = await _readRepository.GetByIdAsync(id);
            if (banner == null) throw new HeadBannerNotFoundException();
            return _mapper.Map<GetHeadBannerDto>(banner);

        }
     

        public async Task<GetHeadBannerDto> Create(CreateHeadBannerDto dto)
        {
            var banner = _mapper.Map<HeadBanner>(dto);
            var createdBanner = await _repository.CreateAsync(banner);
            return _mapper.Map<GetHeadBannerDto>(createdBanner);
        }
        public async Task Update( UpdateHeadBannerDto dto)
        {
            var Banner = await _readRepository.GetByIdAsync(dto.Id) ;
            if (Banner == null)
            {
                throw new HeadBannerNotFoundException();
            }
            await Task.Run(() => _mapper.Map(dto, Banner));
            await _repository.UpdateAsync(Banner);
        }

        public async Task Remove(Guid id)
        {
            var Banner = await _readRepository.GetByIdAsync(id);
            if(Banner == null)
            {
                throw new HeadBannerNotFoundException();
            }
            await _repository.DeleteAsync(Banner);
        }
        
    }
}
