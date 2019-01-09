using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace eCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
  
        // POST api/values
        [HttpPost]
        public IActionResult NewUser([FromBody] User user)
        {
            
        }
    }
}