using ProgrammingPro.Client.Interfaces;
using ProgrammingPro.Shared.Dtos;
using System.Net.Http.Json;

namespace ProgrammingPro.Client.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _http;

        public UserRepository(HttpClient http)
        {
            _http = http;
        }

        public async Task<ICollection<UserDto>> GetAllUsers()
        {
            var response = await _http.GetAsync("api/User");

            return await response.Content.ReadFromJsonAsync<ICollection<UserDto>>();
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var response = await _http.GetAsync($"api/User/{id}");

            return await response.Content.ReadFromJsonAsync<UserDto>();
        }

        public async Task<bool> UserCheck(UserDto userDto)
        {
            var response = await _http.PostAsJsonAsync("api/User/check", userDto);

            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> UserExists(UserDto userDto)
        {
            var response = await _http.PostAsJsonAsync("api/User/exists", userDto);

            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> IsAdmin(UserDto userDto)
        {
            var response = await _http.PostAsJsonAsync("api/User/is-admin", userDto);

            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> IsUser(UserDto userDto)
        {
            var response = await _http.PostAsJsonAsync("api/User/is-user", userDto);

            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<string> Create(UserDto userDto)
        {
            var response = await _http.PostAsJsonAsync("api/User", userDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(UserDto userDto)
        {
            var response = await _http.PatchAsJsonAsync("api/User", userDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _http.DeleteAsync($"api/User/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
