using ProgrammingPro.Shared.Dtos;

namespace ProgrammingPro.Client.Interfaces
{
    public interface ILessonRepository
    {
        Task<ICollection<LessonDto>> GetAllLessons(int courseId);
        Task<LessonDto> GetLessonById(int courseId, int id);
        Task<string> Create(LessonDto lessonDto, int courseId);
        Task<string> Update(LessonDto lessonDto);
        Task<string> Delete(int id);
    }
}
