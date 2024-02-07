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
    public class DocController : ControllerBase
    {
        private readonly IDocRepository _docRepository;
        private readonly IMapper _mapper;

        public DocController(IDocRepository docRepository, IMapper mapper)
        {
            _docRepository = docRepository;
            _mapper = mapper;
        }

        [HttpGet("{courseId}/{lessonId}")]
        public async Task<IActionResult> GetAllDocs(int courseId, int lessonId)
        {
            var docsDto = _mapper.Map<List<DocDto>>(await _docRepository.GetAllDocs(courseId, lessonId));

            return Ok(docsDto);
        }

        [HttpGet("{courseId}/{lessonId}/{id}")]
        public async Task<IActionResult> GetDocById(int courseId, int lessonId, int id)
        {
            var docDto = _mapper.Map<DocDto>(await _docRepository.GetDocById(courseId, lessonId, id));

            return Ok(docDto);
        }

        [HttpPost("{courseId}/{lessonId}")]
        public IActionResult CreateDoc([FromBody] DocDto docDto, int courseId, int lessonId) 
        {
            var doc = _mapper.Map<Doc>(docDto);

            doc.CourseId = courseId;
            doc.LessonId = lessonId;

            _docRepository.Create(doc);

            return Ok("Succeeded");
        }

        [HttpPatch]
        public IActionResult UpdateDoc([FromBody] DocDto docDto)
        {
            var doc = _mapper.Map<Doc>(docDto);

            _docRepository.Update(doc);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoc(int id)
        {
            _docRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
