using ProgrammingPro.Shared.Dtos;

namespace ProgrammingPro.Client.Interfaces
{
    public interface IMaterialRepository
    {
        Task<ICollection<MaterialDto>> GetAllMaterials(int courseId, int lessonId, int homeworkId);
        Task<MaterialDto> GetMaterialById(int courseId, int lessonId, int homeworkId, int id);
        Task<string> Create(MaterialDto materialDto, int courseId, int lessonId, int homeworkId);
        Task<string> Update(MaterialDto materialDto);
        Task<string> Delete(int id);
    }
}
