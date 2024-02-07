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
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;

        public TestController(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetAllTests(int courseId)
        {
            var testsDto = _mapper.Map<List<TestDto>>(await _testRepository.GetAllTests(courseId));

            return Ok(testsDto);
        }

        [HttpGet("{courseId}/{id}")]
        public async Task<IActionResult> GetTestById(int courseId, int id)
        {
            var testDto = _mapper.Map<TestDto>(await _testRepository.GetTestById(courseId, id));

            return Ok(testDto);
        }

        [HttpPost("{courseId}")]
        public IActionResult CreateTest([FromBody] TestDto testDto, int courseId)
        {
            var test = _mapper.Map<Test>(testDto);

            test.CourseId = courseId;

            _testRepository.Create(test);

            return Ok("Succeeded");
        }

        [HttpPatch]
        public IActionResult UpdateTest([FromBody] TestDto testDto)
        {
            var test = _mapper.Map<Test>(testDto);

            _testRepository.Update(test);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTest(int id)
        {
            _testRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
