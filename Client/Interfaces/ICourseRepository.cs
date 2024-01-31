using ProgrammingPro.Shared.Dtos;

namespace ProgrammingPro.Client.Interfaces
{
    public interface ICourseRepository
    {
        Task<ICollection<CourseDto>> GetAllCourses();
        Task<CourseDto> GetCourseById(int id);
        Task<string> Create(CourseDto course);
        Task<string> Update(CourseDto course);
        Task<string> Delete(int id);
    }
}
