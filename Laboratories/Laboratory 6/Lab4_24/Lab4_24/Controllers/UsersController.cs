using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab4_24.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_24.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserByUsername([FromBody] string username)
        {
            return Ok(await _userService.GetUserByUsername(username));
        }
    }
}
