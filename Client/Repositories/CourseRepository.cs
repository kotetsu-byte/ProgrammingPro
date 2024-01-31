using ProgrammingPro.Client.Interfaces;
using ProgrammingPro.Shared.Dtos;
using System.Net.Http.Json;

namespace ProgrammingPro.Client.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly HttpClient _http;

        public CourseRepository(HttpClient http)
        {
            _http = http;
        }

        public async Task<ICollection<CourseDto>> GetAllCourses()
        {
            var response = await _http.GetAsync("api/Course");

            return await response.Content.ReadFromJsonAsync<ICollection<CourseDto>>();
        }

        public async Task<CourseDto> GetCourseById(int id)
        {
            var response = await _http.GetAsync($"api/Course/{id}");

            return await response.Content.ReadFromJsonAsync<CourseDto>();
        }

        public async Task<string> Create(CourseDto courseDto)
        {
            var response = await _http.PostAsJsonAsync("api/Course", courseDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(CourseDto courseDto)
        {
            var response = await _http.PatchAsJsonAsync("api/Course", courseDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _http.DeleteAsync($"api/Course/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
