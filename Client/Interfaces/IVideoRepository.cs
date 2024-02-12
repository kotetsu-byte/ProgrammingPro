using ProgrammingPro.Shared.Dtos;

namespace ProgrammingPro.Client.Interfaces
{
    public interface IVideoRepository
    {
        Task<ICollection<VideoDto>> GetAllVideos(int courseId, int lessonId);
        Task<VideoDto> GetVideoById(int courseId, int lessonId, int id);
        Task<string> Create(VideoDto videoDto, int courseId, int lessonId);
        Task<string> Update(VideoDto videoDto);
        Task<string> Delete(int id);
    }
}
