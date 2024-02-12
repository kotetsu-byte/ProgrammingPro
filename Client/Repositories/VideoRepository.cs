using ProgrammingPro.Client.Interfaces;
using ProgrammingPro.Shared.Dtos;
using System.Net.Http.Json;

namespace ProgrammingPro.Client.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly HttpClient _http;

        public VideoRepository(HttpClient http)
        {
            _http = http;
        }

        public async Task<ICollection<VideoDto>> GetAllVideos(int courseId, int lessonId)
        {
            var response = await _http.GetAsync($"api/Video/{courseId}/{lessonId}");

            return await response.Content.ReadFromJsonAsync<ICollection<VideoDto>>();
        }

        public async Task<VideoDto> GetVideoById(int courseId, int lessonId, int id)
        {
            var response = await _http.GetAsync($"api/Video/{courseId}/{lessonId}/{id}");

            return await response.Content.ReadFromJsonAsync<VideoDto>();
        }

        public async Task<string> Create(VideoDto videoDto, int courseId, int lessonId)
        {
            var response = await _http.PostAsJsonAsync($"api/Video/{courseId}/{lessonId}", videoDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(VideoDto videoDto)
        {
            var response = await _http.PatchAsJsonAsync("api/Video", videoDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _http.DeleteAsync($"api/Video/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
