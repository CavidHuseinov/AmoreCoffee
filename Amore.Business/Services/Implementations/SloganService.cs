using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Slogan;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Interfaces;
using Amore.Core.Entities;
using Amore.DAL.Repositories.Interfaces;
using AutoMapper;

namespace Amore.Business.Services.Implementations
{
    public class SloganService : ISloganService
    {
        private readonly IWriteRepository<Slogan> _writeRepository;
        private readonly IReadRepository<Slogan> _readRepository;
        private IMapper _mapper;

        public SloganService(IMapper mapper, IReadRepository<Slogan> readRepository, IWriteRepository<Slogan> writeRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<IEnumerable<GetSloganDto>> GetAllAsync()
        {
            var slogan = await _readRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetSloganDto>>(slogan);
        }

        public async Task<GetSloganDto> GetByIdAsync(Guid id)
        {
            var slogan = await _readRepository.GetByIdAsync(id);
            if (slogan == null) throw new SloganNotFoundException();
            return _mapper.Map<GetSloganDto>(slogan);
        }

        public async Task<GetSloganDto> CreateAsync(CreateSloganDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto), "Dto error verir");
            var slogan = _mapper.Map<Slogan>(dto);
            var slogannew = await _writeRepository.CreateAsync(slogan);
            return _mapper.Map<GetSloganDto>(slogannew);

        }

        public async Task UpdateAsync(UpdateSloganDto dto)
        {
            var slogan = await _readRepository.GetByIdAsync(dto.Id);
            if (slogan == null) throw new SloganCannotBeUpdate();

            _mapper.Map(dto, slogan);
            await _writeRepository.UpdateAsync(slogan);
        }

        public async Task RemoveAsync(Guid id)
        {
            var slogan = await _readRepository.GetByIdAsync(id);
            if (slogan == null)
            {
                throw new Exception("Slayder Tapilmadi.");
            }
            await _writeRepository.DeleteAsync(slogan);
        }
    }
}
