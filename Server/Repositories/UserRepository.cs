using Microsoft.EntityFrameworkCore;
using ProgrammingPro.Server.Data;
using ProgrammingPro.Server.Interfaces;
using ProgrammingPro.Server.Models;

namespace ProgrammingPro.Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public bool UserCheck(User user)
        {
            if (_context.Users.Any(u => u.UserName == user.UserName && u.PasswordHash == user.PasswordHash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UserExists(User user)
        {
            if(_context.Users.Any(u => u.UserName == user.UserName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsAdmin(User user)
        {
            if(user.Role == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsUser(User user)
        {
            if(user.Role == "User")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Create(User user)
        {
            _context.Users.Add(user);

            return Save();
        }

        public bool Update(User user)
        {
            _context.Users.Update(user);

            return Save();
        }

        public bool Delete(int id)
        {
            var user = _context.Users.Where(u => u.Id == id).FirstOrDefault();

            _context.Users.Remove(user);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
