using ProgrammingPro.Server.Models;

namespace ProgrammingPro.Server.Interfaces
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        bool UserCheck(User user);
        bool UserExists(User user);
        bool IsAdmin(User user);
        bool IsUser(User user);
        bool Create(User user);
        bool Update(User user);
        bool Delete(int id);
        bool Save();
    }
}
