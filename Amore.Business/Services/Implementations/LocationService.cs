using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Location;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Interfaces;
using Amore.Core.Entities;
using Amore.DAL.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Amore.Business.Services.Implementations
{
    public class LocationService : ILocationService
    {
        private readonly IReadRepository<Location> _readRepository;
        private readonly IWriteRepository<Location> _writeRepository;
        private readonly IMapper _mapper;

        public LocationService(IMapper mapper, IWriteRepository<Location> writeRepository, IReadRepository<Location> readRepository)
        {
            _mapper = mapper;
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }
        public async Task<IEnumerable<GetLocationDto>> GetAllAsync()
        {
            var locations = await _readRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetLocationDto>>(locations);
        }
        public async Task<GetLocationDto> GetByIdAsync(Guid id)
        {
            var location = await _readRepository.GetByIdAsync(id);
            if (location == null) throw new LocationNotFoundException();

            return _mapper.Map<GetLocationDto>(location);
        }
        public async Task<GetLocationDto> CreateAsync(CreateLocationDto dto)
        {
            var location = _mapper.Map<Location>(dto);

            var locationnew = await _writeRepository.CreateAsync(location);
            return _mapper.Map<GetLocationDto>(locationnew);
        }

        public async Task UpdateAsync(UpdateLocationDto dto)
        {
            var location = await _readRepository.GetByIdAsync(dto.Id);
            if (location == null) throw new LocationNotFoundException();

            _mapper.Map(dto, location);
            await _writeRepository.UpdateAsync(location);
        }

        public async Task RemoveAsync(Guid id)
        {
            var location = await _readRepository.GetByIdAsync(id);
            if (location == null)
            {
                throw new Exception("Location Tapilmadi.");
            }
            await _writeRepository.DeleteAsync(location);
        }


    }
}
