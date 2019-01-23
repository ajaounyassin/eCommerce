using System.Security.Cryptography;
using System.Threading.Tasks;
using eCommerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Repositories.Interfaces;

namespace eCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("eCommercePolicy")]

    public class UserController : ControllerBase
    {
        private SHA256CryptoServiceProvider SHA256;
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = (UserService)userService;
        }

        [HttpPost("create")]
        public IActionResult New([FromBody] User user)
        {
            if (_userService.Create(user) is null)
                return BadRequest();

            return CreatedAtAction("create",user);
            
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(string mail, string password)
        {
            var user = await _userService.Authenticate(mail, password);

            if (user == false)
                return BadRequest(new { message = "Username or password is incorrect" });

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