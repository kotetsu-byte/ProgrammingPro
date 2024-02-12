using ProgrammingPro.Shared.Dtos;

namespace ProgrammingPro.Client.Interfaces
{
    public interface IDocRepository
    {
        Task<ICollection<DocDto>> GetAllDocs(int courseId, int lessonId);
        Task<DocDto> GetDocById(int courseId, int lessonId, int id);
        Task<string> Create(DocDto docDto, int courseId, int lessonId);
        Task<string> Update(DocDto docDto);
        Task<string> Delete(int id);
    }
}
