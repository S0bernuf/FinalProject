using FinalProject.BusinessLogic.Dtos;
using FinalProject.BusinessLogic.Services.Interfaces;
using FinalProject.Database.Entities;
using FinalProject.Database.Repositories.Interfaces;


namespace FinalProject.BusinessLogic.Services
{

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
            // Check if user exists
            if (await _userRepository.UserExistsAsync(dto.UserName))
                return new ServiceResponse<User> { Success = false, Message = "User already exists." };
            // Create user
            var user = _jwtService.CreateUser(dto.UserName, dto.Password);
            user.Role = "User"; //Pridedama defaultine role, pakeisti i admin duombazeje

            await _userRepository.AddUserAsync(user);
            return new ServiceResponse<User> { Success = true, Data = user };
        }

        public async Task<ServiceResponse<User>> LoginAsync(UserLoginDto dto)
        {
            // Validate user
            var user = await _userRepository.GetUserByNameAsync(dto.UserName);
            if (user == null || !_jwtService.VerifyPassword(dto.Password, user.PasswordHash, user.PasswordSalt))
                return new ServiceResponse<User> { Success = false, Message = "Invalid credentials" };

            return new ServiceResponse<User> { Success = true, Data = user };
        }

        public async Task<ServiceResponse<bool>> DeleteUserAsync(int userId)
        {

            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null) return new ServiceResponse<bool> { Success = false, Message = "User not found" };

            await _userRepository.DeleteUserAsync(user);
            return new ServiceResponse<bool> { Success = true, Data = true };
        }

        public async Task<ServiceResponse<List<User>>> GetAllUsersAsync()
        {
            var user = await _userRepository.GetAllUsersAsync();
            if (user == null) return new ServiceResponse<List<User>> { Success = false, Message = "No User found" };

            var users = await _userRepository.GetAllUsersAsync();
            return new ServiceResponse<List<User>> { Success = true, Data = users };
        }

        public async Task<ServiceResponse<User>> GetUserAsync(int userId)
        {
            var result = await _userRepository.GetUserByIdAsync(userId);
            return new ServiceResponse<User> { Success = true, Data = result };
        }
    }
}
