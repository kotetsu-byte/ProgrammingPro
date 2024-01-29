using Microsoft.EntityFrameworkCore;
using ProgrammingPro.Server.Data;
using ProgrammingPro.Server.Interfaces;
using ProgrammingPro.Server.Models;

namespace ProgrammingPro.Server.Repositories
{
    public class UserCourseRepository : IUserCourseRepository
    {
        private readonly DataContext _context;

        public UserCourseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<UserCourse>> GetAllUserCourses()
        {
            return await _context.UserCourses.ToListAsync();
        }

        public async Task<UserCourse> GetUserCourseById(int userId, int courseId)
        {
            return await _context.UserCourses.Where(uc => uc.UserId == userId && uc.CourseId == courseId).FirstOrDefaultAsync();
        }

        public bool Create(UserCourse userCourse)
        {
            _context.UserCourses.Add(userCourse);

            return Save();
        }

        public bool Update(UserCourse userCourse)
        {
            _context.UserCourses.Update(userCourse);

            return Save();
        }

        public bool Delete(int userId, int courseId) 
        {
            var userCourse = _context.UserCourses.Where(uc => uc.UserId == userId && uc.CourseId == courseId).FirstOrDefault();
            
            _context.UserCourses.Remove(userCourse);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
