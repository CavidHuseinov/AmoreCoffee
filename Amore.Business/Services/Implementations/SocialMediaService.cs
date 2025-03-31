using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.SocialMedia;
using Amore.Business.Helpers.DTOs.SocialMedia;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Interfaces;
using Amore.Core.Entities;
using Amore.DAL.Repositories.Interfaces;
using AutoMapper;

namespace Amore.Business.Services.Implementations
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IWriteRepository<SocialMedia> _writeRepository;
        private readonly IReadRepository<SocialMedia> _readRepository;
        private readonly IMapper _mapper;

        public SocialMediaService(IMapper mapper, IReadRepository<SocialMedia> readRepository, IWriteRepository<SocialMedia> writeRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<IEnumerable<GetSocialMediaDto>> GetAllAsync()
        {
            var socialmedias = await _readRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetSocialMediaDto>>(socialmedias);
        }
        public async Task<GetSocialMediaDto> GetByIdAsync(Guid id)
        {
            var socialmedia = await _readRepository.GetByIdAsync(id);
            if (socialmedia == null) throw new SocialMediaNotFoundException();

            return _mapper.Map<GetSocialMediaDto>(socialmedia);
        }
        public async Task<GetSocialMediaDto> CreateAsync(CreateSocialMediaDto dto)
        {
            var socialmedia = _mapper.Map<SocialMedia>(dto);

            var socialmedianew = await _writeRepository.CreateAsync(socialmedia);
            return _mapper.Map<GetSocialMediaDto>(socialmedianew);
        }

        public async Task UpdateAsync(UpdateSocialMediaDto dto)
        {
            var socialmedia = await _readRepository.GetByIdAsync(dto.Id);
            if (socialmedia == null) throw new SocialMediaNotFoundException();

            _mapper.Map(dto, socialmedia);
            await _writeRepository.UpdateAsync(socialmedia);
        }

        public async Task RemoveAsync(Guid id)
        {
            var socialmedia = await _readRepository.GetByIdAsync(id);
            if (socialmedia == null)
            {
                throw new Exception("SocialMedia Tapilmadi.");
            }
            await _writeRepository.DeleteAsync(socialmedia);
        }
    }
}
