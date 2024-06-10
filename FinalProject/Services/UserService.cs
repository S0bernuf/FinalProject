using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FinalProject.BusinessLogic.Dtos;
using FinalProject.BusinessLogic.Services.Interfaces;
using FinalProject.Database.Entities;
using FinalProject.Database.Repositories.Interfaces;


namespace FinalProject.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        
        

        public UserService(IUserRepository userRepository )
        {
            _userRepository = userRepository;
            
            
        }

        public async Task<ServiceResponse<User>> RegisterAsync(UserSignupDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<User>> LoginAsync(UserLoginDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<bool>> DeleteUserAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
                return new ServiceResponse<bool> { Success = false, Message = "User not found" };

            await _userRepository.DeleteUserAsync(user);
            return new ServiceResponse<bool> { Success = true, Data = true };
        }

        public async Task<ServiceResponse<List<User>>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
