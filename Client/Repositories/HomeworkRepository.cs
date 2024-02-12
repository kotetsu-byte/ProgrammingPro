using ProgrammingPro.Client.Interfaces;
using ProgrammingPro.Shared.Dtos;
using System.Net.Http.Json;

namespace ProgrammingPro.Client.Repositories
{
    public class HomeworkRepository : IHomeworkRepository
    {
        private readonly HttpClient _http;

        public HomeworkRepository(HttpClient http)
        {
            _http = http;
        }

        public async Task<ICollection<HomeworkDto>> GetAllHomeworks(int courseId, int lessonId)
        {
            var response = await _http.GetAsync($"api/Homework/{courseId}/{lessonId}");

            return await response.Content.ReadFromJsonAsync<ICollection<HomeworkDto>>();
        }

        public async Task<HomeworkDto> GetHomeworkById(int courseId, int lessonId, int id)
        {
            var response = await _http.GetAsync($"api/Homework/{courseId}/{lessonId}/{id}");

            return await response.Content.ReadFromJsonAsync<HomeworkDto>();
        }

        public async Task<string> Create(HomeworkDto homeworkDto, int courseId, int lessonId)
        {
            var response = await _http.PostAsJsonAsync($"api/Homework/{courseId}/{lessonId}", homeworkDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(HomeworkDto homeworkDto)
        {
            var response = await _http.PatchAsJsonAsync("api/Homework", homeworkDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _http.DeleteAsync($"api/Homework/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
