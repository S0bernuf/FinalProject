using FinalProject.BusinessLogic.Dtos;
using FinalProject.Database.Entities;
using FinalProject.Database.Repositories.Interfaces;

namespace FinalProject.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> RegisterAsync(UserSignupDto dto);
        Task<ServiceResponse<User>> LoginAsync(UserLoginDto dto);
        Task<ServiceResponse<bool>> DeleteUserAsync(int userId);
        Task<ServiceResponse<List<User>>> GetUsersAsync();
    }
}
