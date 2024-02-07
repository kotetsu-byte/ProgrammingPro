using ProgrammingPro.Server.Models;

namespace ProgrammingPro.Server.Interfaces
{
    public interface IHomeworkRepository
    {
        Task<ICollection<Homework>> GetAllHomeworks(int courseId, int lessonId);
        Task<Homework> GetHomeworkById(int courseId, int lessonId, int id);
        bool Create(Homework homework);
        bool Update(Homework homework);
        bool Delete(int id);
        bool Save();
    }
}
