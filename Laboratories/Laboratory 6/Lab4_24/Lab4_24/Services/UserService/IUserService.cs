using Lab4_24.Models.DTOs;

namespace Lab4_24.Services.UserService;

public interface IUserService
{
    Task<List<UserDto>> GetAllUsers();
    Task<UserDto> GetUserByUsername(string username);
}