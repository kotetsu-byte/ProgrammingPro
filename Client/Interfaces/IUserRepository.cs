using ProgrammingPro.Shared.Dtos;

namespace ProgrammingPro.Client.Interfaces
{
    public interface IUserRepository
    {
        Task<ICollection<UserDto>> GetAllUsers();
        Task<UserDto> GetUserById(int id);
        Task<bool> UserCheck(UserDto userDto);
        Task<bool> UserExists(UserDto userDto);
        Task<bool> IsAdmin(UserDto userDto);
        Task<bool> IsUser(UserDto userDto);
        Task<string> Create(UserDto userDto);
        Task<string> Update(UserDto userDto);
        Task<string> Delete(int id);
    }
}
