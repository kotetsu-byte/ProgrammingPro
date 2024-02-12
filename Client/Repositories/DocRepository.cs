using ProgrammingPro.Client.Interfaces;
using ProgrammingPro.Shared.Dtos;
using System.Net.Http.Json;

namespace ProgrammingPro.Client.Repositories
{
    public class DocRepository : IDocRepository
    {
        private readonly HttpClient _http;

        public DocRepository(HttpClient http)
        {
            _http = http;
        }

        public async Task<ICollection<DocDto>> GetAllDocs(int courseId, int lessonId)
        {
            var response = await _http.GetAsync($"api/Doc/{courseId}/{lessonId}");

            return await response.Content.ReadFromJsonAsync<ICollection<DocDto>>();
        }

        public async Task<DocDto> GetDocById(int courseId, int lessonId, int id)
        {
            var response = await _http.GetAsync($"api/Doc/{courseId}/{lessonId}/{id}");

            return await response.Content.ReadFromJsonAsync<DocDto>();
        }

        public async Task<string> Create(DocDto docDto, int courseId, int lessonId)
        {
            var response = await _http.PostAsJsonAsync($"api/Doc/{courseId}/{lessonId}", docDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(DocDto docDto)
        {
            var response = await _http.PatchAsJsonAsync("api/Doc", docDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _http.DeleteAsync($"api/Doc/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
