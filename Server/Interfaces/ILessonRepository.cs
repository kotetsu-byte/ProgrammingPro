using ProgrammingPro.Server.Models;

namespace ProgrammingPro.Server.Interfaces
{
    public interface ILessonRepository
    {
        Task<ICollection<Lesson>> GetAllLessons(int courseId);
        Task<Lesson> GetLessonById(int courseId, int id);
        bool Create(Lesson lesson);
        bool Update(Lesson lesson);
        bool Delete(int id);
        bool Save();
    }
}
