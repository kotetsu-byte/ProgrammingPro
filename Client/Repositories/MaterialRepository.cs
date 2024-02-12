using ProgrammingPro.Client.Interfaces;
using ProgrammingPro.Shared.Dtos;
using System.Net.Http.Json;

namespace ProgrammingPro.Client.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly HttpClient _http;

        public MaterialRepository(HttpClient http)
        {
            _http = http;
        }

        public async Task<ICollection<MaterialDto>> GetAllMaterials(int courseId, int lessonId, int homeworkId)
        {
            var response = await _http.GetAsync($"api/Material/{courseId}/{lessonId}/{homeworkId}");

            return await response.Content.ReadFromJsonAsync<ICollection<MaterialDto>>();
        }

        public async Task<MaterialDto> GetMaterialById(int courseId, int lessonId, int homeworkId, int id)
        {
            var response = await _http.GetAsync($"api/Material/{courseId}/{lessonId}/{homeworkId}/{id}");

            return await response.Content.ReadFromJsonAsync<MaterialDto>();
        }

        public async Task<string> Create(MaterialDto materialDto, int courseId, int lessonId, int homeworkId)
        {
            var response = await _http.PostAsJsonAsync($"api/Material/{courseId}/{lessonId}/{homeworkId}", materialDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(MaterialDto materialDto)
        {
            var response = await _http.PatchAsJsonAsync("api/Material", materialDto);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
            var response = await _http.DeleteAsync($"api/Material/{id}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
