using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Product;
using Amore.Business.Helpers.DTOs.User;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Interfaces;
using Amore.Core.Entities;
using Amore.DAL.Context;
using Amore.DAL.Repositories.Implementations;
using Amore.DAL.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Amore.Business.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly AmoreDbContext _context;
        private readonly IHttpContextAccessor _httpContextAcessor;

        public UserService(IMapper mapper, IConfiguration config, IEmailService emailService, UserManager<AppUser> userManager, AmoreDbContext context, IHttpContextAccessor httpContextAcessor)
        {
            _mapper = mapper;
            _config = config;
            _emailService = emailService;
            _userManager = userManager;
            _context = context;
            _httpContextAcessor = httpContextAcessor;
        }
        public async Task<UserDto> GetByIdAsync()
        {
            var userId = _httpContextAcessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                throw new UserNotFoundException("İstifadəçi tapılmadı");

            var user = await _userManager.Users
                .Include(x => x.UserPromocodes).ThenInclude(x => x.Promocode)
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            if (user == null)
                throw new UserNotFoundException("İstifadəçi tapılmadı");

            return _mapper.Map<UserDto>(user);
        }

        public async Task<ICollection<UserDto>> GetAllAsync()
        {
            var users = await _userManager.Users
                .Include(x => x.UserPromocodes).ThenInclude(x => x.Promocode)
                .ToListAsync(); 

            return _mapper.Map<ICollection<UserDto>>(users);
        }
        public async Task<ICollection<UserDto>> GetAllWithDetailsAsync()
        {
            var users = await _context.Users
                .Include(x => x.UserPromocodes)
                .ThenInclude(x => x.Promocode).ToListAsync();
            return _mapper.Map<ICollection<UserDto>>(users);
        }



        public async Task RegisterAsync(RegisterDto dto)
        {
            if (await _userManager.FindByNameAsync(dto.UserName) != null)
                throw new RegisterNotFoundException("Bu istifadəçi artıq mövcuddur");

            if (await _userManager.FindByEmailAsync(dto.Email) != null)
                throw new RegisterNotFoundException("Bu istifadəçi artıq mövcuddur");

            if (string.IsNullOrEmpty(dto.ImgUrl))
            {
                dto.ImgUrl = "ProfilePhoto.png";
            }

            var user = _mapper.Map<AppUser>(dto);

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var error in result.Errors)
                {
                    sb.AppendLine(error.Description);
                }

                throw new RegisterNotFoundException(sb.ToString());
            }

            user.ImgUrl = dto.ImgUrl;
            await _userManager.UpdateAsync(user);
        }



        public async Task<string> LoginAsync(LoginDto dto)
        {
            AppUser? user = await _userManager.FindByEmailAsync(dto.UserNameOrEmail) ??
                            await _userManager.FindByNameAsync(dto.UserNameOrEmail);

            if (user == null) throw new LoginNotFoundException();

            var result = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!result) throw new LoginNotFoundException();

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim("Name", user.Name),
        new Claim(ClaimTypes.Email, user.Email)
    };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(3),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public async Task ForgotPasswordAsync(ForgotPasswordDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
                throw new UserNotFoundException("Bu e-posta adresinə aid bir hesab tapılmadı");

            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            string encodedToken = WebUtility.UrlEncode(resetToken);

            string resetUrl = $"{_config["Frontend:BaseUrl"]}/reset-password?email={dto.Email}&token={encodedToken}";

            await _emailService.SendEmailAsync(dto.Email, "Şifrəni sıfırlamaq",
                $"Şifrənizi sıfırlamaq üçün <a href='{resetUrl}'>buraya daxil olun</a>");

            return;
        }

        public async Task ResetPasswordAsync(ResetPasswordDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
                throw new UserNotFoundException("Istifadəçi tapılmadı");

            string decodedToken = WebUtility.UrlDecode(dto.Token);

            var result = await _userManager.ResetPasswordAsync(user, decodedToken, dto.NewPassword);

            if (!result.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    sb.AppendLine(error.Description);
                }
                throw new ArgumentException("Ugursuz oldu");
            }

            return;
        }




        //Admin 

        public async Task RegisterAdminAsync(RegisterDto dto)
        {
            if (await _userManager.FindByNameAsync(dto.UserName) != null)
                throw new RegisterNotFoundException("Bu istifadəçi artıq mövcuddur");

            if (await _userManager.FindByEmailAsync(dto.Email) != null)
                throw new RegisterNotFoundException("Bu e-posta artıq mövcuddur");

            if (string.IsNullOrEmpty(dto.ImgUrl))
            {
                dto.ImgUrl = "ProfilePhoto.png";
            }

            var user = _mapper.Map<AppUser>(dto);
            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    sb.AppendLine(error.Description);
                }
                throw new RegisterNotFoundException(sb.ToString());
            }

            await _userManager.AddToRoleAsync(user, "Admin");
        }

        public async Task UpdateAsync(ProfileUpdateDto dto)
        {
            var user = await _userManager.GetUserAsync(_httpContextAcessor.HttpContext.User);

            if (user == null)
            {
                throw new Exception("İstifadəçi tapılmadı");
            }

            if (!string.IsNullOrEmpty(dto.ImgUrl))
            {
                user.ImgUrl = dto.ImgUrl;
            }

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                throw new Exception("Şəxsi kabinetdəki məlumatları yeniləmək mümkün olmadı");
            }

        }
    }

}
