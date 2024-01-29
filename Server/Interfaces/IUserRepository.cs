using ProgrammingPro.Server.Models;

namespace ProgrammingPro.Server.Interfaces
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        bool Create(User user);
        bool Update(User user);
        bool Delete(int id);
        bool Save();
    }
}
