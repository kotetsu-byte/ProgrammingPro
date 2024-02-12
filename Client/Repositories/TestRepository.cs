using ProgrammingPro.Client.Interfaces;
using ProgrammingPro.Shared.Dtos;
using System.Net.Http.Json;

namespace ProgrammingPro.Client.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly HttpClient _http;

        public TestRepository(HttpClient http)
        {
            _http = http;
        }

        public async Task<ICollection<TestDto>> GetAllTests(int courseId)
        {
            var response = await _http.GetAsync($"api/Test/{courseId}");

            return await response.Content.ReadFromJsonAsync<ICollection<TestDto>>();
        }

        public async Task<TestDto> GetTestById(int courseId, int id)
        {
            var response = await _http.GetAsync($"api/Test/{courseId}/{id}");

            return await response.Content.ReadFromJsonAsync<TestDto>();
        }

        public async Task<string> Create(TestDto testDto, int courseId)
        {
            var response = await _http.PostAsJsonAsync($"api/Test/{courseId}", testDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(TestDto testDto)
        {
            var response = await _http.PatchAsJsonAsync("api/Test", testDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _http.DeleteAsync($"api/Test/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
