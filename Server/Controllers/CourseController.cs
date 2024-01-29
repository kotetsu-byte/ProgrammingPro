﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingPro.Server.Dtos;
using ProgrammingPro.Server.Interfaces;
using ProgrammingPro.Server.Models;

namespace ProgrammingPro.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseController(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var coursesDto = _mapper.Map<List<CourseDto>>(await _courseRepository.GetAllCourses());

            return Ok(coursesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var courseDto = _mapper.Map<CourseDto>(await _courseRepository.GetCourseById(id));

            return Ok(courseDto);
        }

        [HttpPost]
        public IActionResult CreateCourse([FromBody] CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);

            _courseRepository.Create(course);

            return Ok("Succeeded");
        }

        [HttpPatch]
        public IActionResult UpdateCourse([FromBody] CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);

            _courseRepository.Update(course);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            _courseRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
