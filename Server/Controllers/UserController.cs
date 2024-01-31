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
