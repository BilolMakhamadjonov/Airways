using Airways.Application.DTO;
using Airways.Core.Entities;
using Airways.DataAccess;

namespace Airways.Application.Services;

public interface IUserService
{
    Task<UserDto> GetByIdAsync(Guid id);
    Task<List<UserDto>> GetAllAsync();
    Task<UserForCreationDto> AddUserAsync(UserForCreationDto userForCreationDto);
    Task<User> UpdateUserAsync(Guid id, UserDto userDto);
    Task<bool> DeleteUserAsync(Guid id);
    Task<User> GetUserByEmailAsync(string email);
    Task<bool> VerifyPassword(User user, string password);
}
