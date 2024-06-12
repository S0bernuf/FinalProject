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
    /*
     * 1. remove not used usings
     * 2.  user.Role = "User"; //Pridedama defaultine role, pakeisti i admin duombazeje
     * better approach would be to add in jwtService in method CreateUser to add    Role = "Admin"
     * 3. Login method missing
     * 4. In DeleteUserAsync method, user == null is not necessary, expression always false
     */
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;


        public UserService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;


        }

        public async Task<ServiceResponse<User>> RegisterAsync(UserSignupDto dto)
        {
            if (await _userRepository.UserExistsAsync(dto.UserName))
                return new ServiceResponse<User> { Success = false, Message = "User already exists." };

            var user = _jwtService.CreateUser(dto.UserName, dto.Password);
            user.Role = "User"; //Pridedama defaultine role, pakeisti i admin duombazeje

            await _userRepository.AddUserAsync(user);
            return new ServiceResponse<User> { Success = true, Data = user };
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
            var result = new ServiceResponse<List<User>>();
            return result;
        }

        public Task<ServiceResponse<User>> GetUserAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
