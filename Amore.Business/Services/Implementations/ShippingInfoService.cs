using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.ShippingInfo;
using Amore.Business.Helpers.DTOs.ShippingInfo;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Interfaces;
using Amore.Core.Entities;
using Amore.DAL.Repositories.Interfaces;
using AutoMapper;

namespace Amore.Business.Services.Implementations
{
    public class ShippingInfoService : IShippingInfoService
    {
        private readonly IShippingInfoRepository _writeRepository;
        private readonly IReadRepository<ShippingInfo> _readRepository;
        private readonly IMapper _mapper;

        public ShippingInfoService(IMapper mapper, IReadRepository<ShippingInfo> readRepository, IShippingInfoRepository writeRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
        public async Task<IEnumerable<GetShippingInfoDto>> GetAllAsync()
        {
            var shippingInfo = await _readRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetShippingInfoDto>>(shippingInfo);

        }

        public async Task<GetShippingInfoDto> GetByIdAsync(Guid id)
        {
            var shippingInfo = await _readRepository.GetByIdAsync(id);
            if (shippingInfo == null) throw new ShippingInfoException();
            return _mapper.Map<GetShippingInfoDto>(shippingInfo);

        }


        public async Task<GetShippingInfoDto> CreateAsync(CreateShippingInfoDto dto)
        {
            var shippingInfo = _mapper.Map<ShippingInfo>(dto);
            var createdShippingInfo = await _writeRepository.CreateAsync(shippingInfo);
            return _mapper.Map<GetShippingInfoDto>(createdShippingInfo);
        }
    }
}
