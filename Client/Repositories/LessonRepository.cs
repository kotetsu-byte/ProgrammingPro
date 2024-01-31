using ProgrammingPro.Client.Interfaces;
using ProgrammingPro.Shared.Dtos;
using System.Net.Http.Json;

namespace ProgrammingPro.Client.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly HttpClient _http;

        public LessonRepository(HttpClient http)
        {
            _http = http;
        }

        public async Task<ICollection<LessonDto>> GetAllLessons(int courseId)
        {
            var response = await _http.GetAsync($"api/Lesson/{courseId}");

            return await response.Content.ReadFromJsonAsync<ICollection<LessonDto>>();
        }

        public async Task<LessonDto> GetLessonById(int courseId, int id)
        {
            var response = await _http.GetAsync($"api/Lesson/{courseId}/{id}");

            return await response.Content.ReadFromJsonAsync<LessonDto>();
        }

        public async Task<string> Create(LessonDto lessonDto, int courseId)
        {
            var response = await _http.PostAsJsonAsync($"api/Lesson/{courseId}", lessonDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(LessonDto lessonDto)
        {
            var response = await _http.PatchAsJsonAsync("api/Lesson", lessonDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _http.DeleteAsync($"api/Lesson/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
