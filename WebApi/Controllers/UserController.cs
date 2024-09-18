using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.CreateUpdateAsync(userDto);
            return Ok(result);
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.Get(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // GET: api/User
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        // GET: api/User/ByEmail?email={email}
        [HttpGet("ByEmail")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            var user = await _userService.GetByEmail(email);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // DELETE: api/User/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.Get(id);
            if (user == null)
                return NotFound();

            await _userService.Remove(id);
            return NoContent();
        }

        // GET: api/User/SearchByEmail?email={email}
        [HttpGet("SearchByEmail")]
        public async Task<IActionResult> SearchByEmail([FromQuery] string email)
        {
            var users = await _userService.SearchByEmail(email);
            return Ok(users);
        }

        // GET: api/User/SearchByName?name={name}
        [HttpGet("SearchByName")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            var users = await _userService.SearchByName(name);
            return Ok(users);
        }
    }
}
