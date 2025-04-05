using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Slogan;
using Amore.Business.Helpers.DTOs.User;

namespace Amore.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync (RegisterDto dto);
        Task<string> LoginAsync(LoginDto dto);
        Task ForgotPasswordAsync(ForgotPasswordDto dto);
        Task ResetPasswordAsync (ResetPasswordDto dto);
        Task RegisterAdminAsync(RegisterDto dto);
        Task<UserDto> GetByIdAsync();
        Task<ICollection<UserDto>> GetAllAsync();
        Task<ICollection<UserDto>> GetAllWithDetailsAsync();
        Task UpdateAsync (ProfileUpdateDto dto);

    }
}
