using eCommerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model.Model;

namespace eCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("eCommercePolicy")]

    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = (UserService)userService;
        }

        [HttpPost("create")]
        public IActionResult New([FromBody] User user)
        {
            if (_userService.Create(user) is null)
                return BadRequest(new { message = "E-Mail already used" });

            return StatusCode(200,"User Created successfully");
            
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User user)
        {
            var exist = _userService.Authenticate(user.Mail, user.Password);

            if (exist)
                return Ok(exist);

            return BadRequest(new { message = "Username or password is incorrect" });
        }

        [HttpGet("GetOne/{email}", Name = "GetOne")]
        public IActionResult GetOne(string email)
        {
            var user = _userService.GetOne(email);
            if (user is null)
                return NotFound();

            return Ok(user);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] User user)
        {
            _userService.Delete(user);
            return NoContent();

        }
    }
}