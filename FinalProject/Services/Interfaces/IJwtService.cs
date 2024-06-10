using FinalProject.Database.Entities;

namespace FinalProject.BusinessLogic.Services.Interfaces;

public interface IJwtService
{
    string GenerateJwtToken(string user, int userId);
    bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt);
    User CreateUser(string username, string password);
}