using FinalProject.Database.Entities;
using FinalProject.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Database.Repositories
{
     /*
     * 1. remove unused usings
     * 2. calling FindAsync() or SingleOfDefaultAsync() might not find anything, and app can crash if not catch in try catch block,
      * or checked if object is null
     * better approach would be to use FirstOrDefaultAsync() 
     * 4.
      * */
    public class UserRepository : IUserRepository
    {
        private readonly FinalProjectDbContext _context;

        public UserRepository(FinalProjectDbContext context)
        {
            _context = context;
        }

        public async Task<bool> UserExistsAsync(string userName)
        {
            return await _context.Users.AnyAsync(u => u.UserName == userName);
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByNameAsync(string userName)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
