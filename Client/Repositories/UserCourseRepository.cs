using ProgrammingPro.Client.Interfaces;
using ProgrammingPro.Shared.Dtos;
using System.Net.Http.Json;

namespace ProgrammingPro.Client.Repositories
{
    public class UserCourseRepository : IUserCourseRepository
    {
        private readonly HttpClient _http;

        public UserCourseRepository(HttpClient http)
        {
            _http = http;
        }

        public async Task<ICollection<UserCourseDto>> GetAllUserCourses()
        {
            var response = await _http.GetAsync("api/UserCourse");

            return await response.Content.ReadFromJsonAsync<ICollection<UserCourseDto>>();
        }

        public async Task<UserCourseDto> GetUserCourseById(int userId, int courseId)
        {
            var response = await _http.GetAsync($"api/UserCourse/{userId}/{courseId}");

            return await response.Content.ReadFromJsonAsync<UserCourseDto>();
        }

        public async Task<string> Create(UserCourseDto userCourseDto)
        {
            var response = await _http.PostAsJsonAsync("api/UserCourse", userCourseDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(UserCourseDto userCourseDto)
        {
            var response = await _http.PatchAsJsonAsync("api/UserCourse", userCourseDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int userId, int courseId)
        {
            var response = await _http.DeleteAsync($"api/UserCourse/{userId}/{courseId}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
