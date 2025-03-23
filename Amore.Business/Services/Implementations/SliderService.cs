using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Slider;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Interfaces;
using Amore.Core.Entities;
using Amore.DAL.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Identity.Client;

namespace Amore.Business.Services.Implementations
{
    public class SliderService : ISliderService
    {
        private readonly IWriteRepository<Slider> _writeRepository;
        private readonly IReadRepository<Slider> _readRepository;
        private readonly IMapper _mapper;

        public SliderService(IMapper mapper, IReadRepository<Slider> readRepository, IWriteRepository<Slider> writeRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<IEnumerable<GetSliderDto>> GetAllAsync()
        {
            var slider = await _readRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetSliderDto>>(slider);
        }

        public async Task<GetSliderDto> GetByIdAsync(Guid id)
        {
            var slider = await _readRepository.GetByIdAsync(id);
            if (slider == null) throw new SliderNotFoundException();
            return _mapper.Map<GetSliderDto>(slider);
        }

        public async Task<GetSliderDto> CreateAsync(CreateSliderDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto),"Dto error verir");
            var slider = _mapper.Map<Slider>(dto);
            var slidernew = await _writeRepository.CreateAsync(slider);
            return _mapper.Map<GetSliderDto>(slidernew);

        }

        public async Task UpdateAsync(UpdateSliderDto dto)
        {
            var slider = await _readRepository.GetByIdAsync(dto.Id);
            if (slider == null) throw new SliderCannotBeUpdate();

            _mapper.Map(dto, slider);
            await _writeRepository.UpdateAsync(slider);
        }

        public async Task RemoveAsync(Guid id)
        {
            var slider = await _readRepository.GetByIdAsync(id);
            if (slider == null)
            {
                throw new Exception("Slayder Tapilmadi.");
            }
            await _writeRepository.DeleteAsync(slider);
        }
    }
}
