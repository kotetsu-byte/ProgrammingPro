using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingPro.Server.Interfaces;
using ProgrammingPro.Server.Models;
using ProgrammingPro.Shared.Dtos;
using System.Diagnostics;

namespace ProgrammingPro.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var usersDto = _mapper.Map<List<UserDto>>(await _userRepository.GetAllUsers());

            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var userDto = _mapper.Map<UserDto>(await _userRepository.GetUserById(id));

            return Ok(userDto);
        }

        [HttpPost("check")]
        public IActionResult CheckUser([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            bool exists = _userRepository.UserCheck(user);

            return Ok(exists);
        }

        [HttpPost("exists")]
        public IActionResult UserExists([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            bool exists = _userRepository.UserExists(user);

            return Ok(exists);
        }

        [HttpPost("is-admin")]
        public IActionResult IsAdmin([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            bool result = _userRepository.IsAdmin(user);

            return Ok(result);
        }

        [HttpPost("is-user")]
        public IActionResult IsUser([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            bool result = _userRepository.IsUser(user);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            _userRepository.Create(user);

            return Ok("Succeeded");
        }

        [HttpPatch]
        public IActionResult UpdateUser([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            _userRepository.Update(user);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
