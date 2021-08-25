using Guilherme.LojaVirtualApi.Models.DTOs;
using Guilherme.LojaVirtualApi.Models.DTOs.Requests;
using Guilherme.LojaVirtualApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Guilherme.LojaVirtualApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn([FromBody] UserDto user)
        {
            var response = await _userService.SignIn(user);

            return Ok(response);
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenDto tokenDto)
        {
            var response = await _userService.RefreshToken(tokenDto);

            return Ok(response);
        }
    }
}
