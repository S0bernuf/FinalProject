using FinalProject.Database.Entities;


namespace FinalProject.Database.Repositories.Interfaces
{

    public interface IUserRepository
    {
        Task<bool> UserExistsAsync(string userName);
        Task AddUserAsync(User user);
        Task<User> GetUserByNameAsync(string userName);
        Task<User> GetUserByIdAsync(int userId);
        Task DeleteUserAsync(User user);
        Task<List<User>> GetAllUsersAsync();
    }
}
