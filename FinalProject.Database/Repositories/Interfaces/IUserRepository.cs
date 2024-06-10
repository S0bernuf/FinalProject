using FinalProject.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
