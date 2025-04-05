using Amore.Core.Entities;
using Amore.DAL.Repositories.Interfaces;
using Amore.Business.Helpers.DTOs.Promocode;
using AutoMapper;
using System;
using System.Threading.Tasks;
using Amore.Business.Services.Interfaces;
using Amore.Business.Helpers.DTOs.Product;
using Microsoft.EntityFrameworkCore;
using Amore.Business.Helpers.DTOs.Order;
using Amore.Business.Helpers.Exceptions;
using Amore.DAL.Context;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Identity;

namespace Amore.Business.Services.Implementations
{
    public class PromocodeService : IPromocodeService
    {
        private readonly IPromocodeRepository _promocodeRepository;
        private readonly IReadRepository<Promocode> _readRepository;
        private readonly IMapper _mapper;
        private readonly AmoreDbContext _context;

        public PromocodeService(IMapper mapper, IReadRepository<Promocode> readRepository, IPromocodeRepository promocodeRepository, AmoreDbContext context)
        {
            _mapper = mapper;
            _readRepository = readRepository;
            _promocodeRepository = promocodeRepository;
            _context = context;
        }
        public async Task<ICollection<GetPromocodeDto>> GetAllAsync()
        {
            var promocodes = await _readRepository.GetAllAsync(
                include: query => query
                    .Include(o => o.UserPromocodes).ThenInclude(op => op.AppUser));

            return _mapper.Map<ICollection<GetPromocodeDto>>(promocodes);
        }

        public async Task<GetPromocodeDto> GetByIdAsync(Guid id)
        {
            var promocodes = await _readRepository.GetAllAsync(
           include: query => query
            .Include(p => p.UserPromocodes).ThenInclude(t => t.AppUser)
);
            var promocode = await _readRepository.GetByIdAsync(id);
            if (promocode == null)
            {
                throw new Exception("Promokod yoxdur");
            }

            return _mapper.Map<GetPromocodeDto>(promocode);
        }

        public async Task<GetPromocodeDto> CreateAsync(CreatePromocodeDto dto)
        {
            var appUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == dto.AppUserName);

            if (appUser == null)
            {
                throw new Exception("Istifadeci tapilmadi");
            }

            var promocode = _mapper.Map<Promocode>(dto);

            var existingPromocode = await _readRepository.GetAllAsync(
                predicate: p => p.Code == promocode.Code
            );

            if (existingPromocode.Any())
            {
                throw new Exception("Bu promokod artıq yaradılıb");
            }

            var createdPromocode = await _promocodeRepository.CreateAsync(promocode);

            createdPromocode.UserPromocodes = new Collection<UserPromocode>();

            createdPromocode.UserPromocodes.Add(new UserPromocode()
            {
                AppUserId = appUser.Id,
                PromocodeId = createdPromocode.Id
            });

            await _promocodeRepository.UpdateAsync(createdPromocode);
            _context.SaveChanges();

            return _mapper.Map<GetPromocodeDto>(createdPromocode);
        }


        public async Task<bool> ValidatePromocodeAsync(string code)
        {
            var promocode = await _readRepository.GetAllAsync(
                predicate: p => p.Code == code && p.IsActive && p.ExpirationDate > DateTime.Now
            );

            return promocode.Any(); 
        }
        public async Task<GetPromocodeDto?> GetPromocodeAsync(string code)
        {
            var promocode = await _readRepository.GetAllAsync(
                predicate: p => p.Code == code && p.IsActive && p.ExpirationDate > DateTime.Now
                );

            var promocodeResult =promocode.FirstOrDefault();

            if (promocodeResult != null)
            {
                return _mapper.Map<GetPromocodeDto?>(promocodeResult);
            }
            return null;
        }
        public async Task<GetPromocodeDto> UsePromocodeAsync(string userId, string promocodeCode)
        {
            var promocode = await _context.Promocodes
                .Include(x => x.UserPromocodes)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Code == promocodeCode); 

            if (promocode == null)
            {
                throw new ArgumentException("Bu Promokod mevcud yoxdur");
            }

            if (promocode.ExpirationDate < DateTime.UtcNow)
            {
                throw new ArgumentException("Aktiv deyil , vaxti bitib");
            }

            if (!promocode.UserPromocodes.Any() || !promocode.UserPromocodes.Any(x => x.AppUserId == userId))
            {
                throw new Exception("Bu promokod daha evvel istifade olunub");
            }

            var userPromocodeRecord = new UserPromocode
            {
                AppUserId = userId,
                PromocodeId = promocode.Id,
            };

            _context.Remove(userPromocodeRecord);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetPromocodeDto>(promocode);
        }




    }
}
