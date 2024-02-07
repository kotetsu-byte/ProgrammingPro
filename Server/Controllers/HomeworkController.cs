using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingPro.Server.Interfaces;
using ProgrammingPro.Server.Models;
using ProgrammingPro.Shared.Dtos;

namespace ProgrammingPro.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly IHomeworkRepository _homeworkRepository;
        private readonly IMapper _mapper;

        public HomeworkController(IHomeworkRepository homeworkRepository, IMapper mapper)
        {
            _homeworkRepository = homeworkRepository;
            _mapper = mapper;
        }

        [HttpGet("{courseId}/{lessonId}")]
        public async Task<IActionResult> GetAllHomeworks(int courseId, int lessonId)
        {
            var homeworksDto = _mapper.Map<List<HomeworkDto>>(await _homeworkRepository.GetAllHomeworks(courseId, lessonId));

            return Ok(homeworksDto);
        }

        [HttpGet("{courseId}/{lessonId}/{id}")]
        public async Task<IActionResult> GetHomeworkById(int courseId, int lessonId, int id)
        {
            var homewrokDto = _mapper.Map<HomeworkDto>(await _homeworkRepository.GetHomeworkById(courseId, lessonId, id));

            return Ok(homewrokDto);
        }

        [HttpPost("{courseId}/{lessonId}")]
        public IActionResult CreateHomework([FromBody] HomeworkDto homeworkDto, int courseId, int lessonId)
        {
            var homework = _mapper.Map<Homework>(homeworkDto);

            homework.CourseId = courseId;
            homework.LessonId = lessonId;

            _homeworkRepository.Create(homework);

            return Ok("Succeeded");
        }

        [HttpPatch]
        public IActionResult UpdateHomework([FromBody] HomeworkDto homeworkDto)
        {
            var homework = _mapper.Map<Homework>(homeworkDto);

            _homeworkRepository.Update(homework);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHomework(int id)
        {
            _homeworkRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
