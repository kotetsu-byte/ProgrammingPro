using ProgrammingPro.Shared.Dtos;

namespace ProgrammingPro.Client.Interfaces
{
    public interface IUserCourseRepository
    {
        Task<ICollection<UserCourseDto>> GetAllUserCourses();
        Task<UserCourseDto> GetUserCourseById(int userId, int courseId);
        Task<string> Create(UserCourseDto userCourseDto);
        Task<string> Update(UserCourseDto userCourseDto);
        Task<string> Delete(int userId, int courseId);
    }
}
