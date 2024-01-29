using ProgrammingPro.Server.Models;

namespace ProgrammingPro.Server.Interfaces
{
    public interface ICourseRepository
    {
        Task<ICollection<Course>> GetAllCourses();
        Task<Course> GetCourseById(int id);
        bool Create(Course course);
        bool Update(Course course);
        bool Delete(int id);
        bool Save();
    }
}
