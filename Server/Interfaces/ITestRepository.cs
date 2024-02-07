using ProgrammingPro.Server.Models;

namespace ProgrammingPro.Server.Interfaces
{
    public interface ITestRepository
    {
        Task<ICollection<Test>> GetAllTests(int courseId);
        Task<Test> GetTestById(int courseId, int id);
        bool Create(Test test);
        bool Update(Test test);
        bool Delete(int id);
        bool Save();
    }
}
