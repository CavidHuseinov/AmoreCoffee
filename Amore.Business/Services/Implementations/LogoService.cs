using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Logo;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Helpers.Extensions;
using Amore.Business.Services.Interfaces;
using Amore.Core.Entities;
using Amore.DAL.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;

namespace Amore.Business.Services.Implementations
{
    public class LogoService : ILogoService
    {
        private readonly IWriteRepository<Logo> _writeRepository;
        private readonly IReadRepository<Logo> _readRepository;
        private readonly IMapper _mapper;

        public LogoService(IWriteRepository<Logo> writeRepository, IReadRepository<Logo> readRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetLogoDto>> GetAllAsync()
        {
            var logos = await _readRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetLogoDto>>(logos);
        }

        public async Task<GetLogoDto> GetByIdAsync(Guid id)
        {
            var logo = await _readRepository.GetByIdAsync(id);
            if (logo == null) throw new LogoNotFoundException();

            return _mapper.Map<GetLogoDto>(logo);
        }   

        public async Task<GetLogoDto> CreateAsync(CreateLogoDto dto)
        {
            var logo = _mapper.Map<Logo>(dto);

           var logonew=  await _writeRepository.CreateAsync(logo);
            return _mapper.Map<GetLogoDto>(logonew);
        }

        public async Task UpdateAsync(UpdateLogoDto dto)
        {
            var logo = await _readRepository.GetByIdAsync(dto.Id);
            if (logo == null) throw new LogoNotFoundException();

            _mapper.Map(dto, logo);
            await _writeRepository.UpdateAsync(logo);
        }

        public async Task RemoveAsync(Guid id)
        {
            var logo = await _readRepository.GetByIdAsync(id);
            if (logo == null)
            {
                throw new Exception("Logo Tapilmadi.");
            }
            await _writeRepository.DeleteAsync(logo);
        }
    }
}
        