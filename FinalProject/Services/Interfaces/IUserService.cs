using FinalProject.BusinessLogic.Dtos;
using FinalProject.Database.Entities;

namespace FinalProject.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> RegisterAsync(UserSignupDto dto);
        Task<ServiceResponse<User>> LoginAsync(UserLoginDto dto);
        Task<ServiceResponse<bool>> DeleteUserAsync(int userId);
        Task<ServiceResponse<List<User>>> GetAllUsersAsync();
        Task<ServiceResponse<User>> GetUserAsync(int userId);
    }
}
