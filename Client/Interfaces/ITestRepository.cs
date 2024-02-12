using ProgrammingPro.Shared.Dtos;

namespace ProgrammingPro.Client.Interfaces
{
    public interface ITestRepository
    {
        Task<ICollection<TestDto>> GetAllTests(int courseId);
        Task<TestDto> GetTestById(int courseId, int id);
        Task<string> Create(TestDto testDto, int courseId);
        Task<string> Update(TestDto testDto);
        Task<string> Delete(int id);
    }
}
