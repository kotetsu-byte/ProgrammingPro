using ProgrammingPro.Shared.Dtos;

namespace ProgrammingPro.Client.Interfaces
{
    public interface IHomeworkRepository
    {
        Task<ICollection<HomeworkDto>> GetAllHomeworks(int courseId, int lessonId);
        Task<HomeworkDto> GetHomeworkById(int courseId, int lessonId, int id);
        Task<string> Create(HomeworkDto homeworkDto, int courseId, int lessonId);
        Task<string> Update(HomeworkDto homeworkDto);
        Task<string> Delete(int id);
    }
}
