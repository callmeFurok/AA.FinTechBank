using AA.FinTechBank.Application.IServices;
using AA.FinTechBank.Common.Utils;
using AA.FinTechBank.Domain.Dto;
using AA.FinTechBank.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AA.FinTechBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IApplicationUserService _userService;
        public UsersController(IApplicationUserService userService)
        {
            _userService = userService;
            
        }


        [HttpPost("/register")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<ApiResponse<CreateUserDto>>> CreateUserAsync([FromBody] CreateUserDto applicationUser)
        {
            var serviceReponse = await _userService.CreatUserAsync(applicationUser);
            if (serviceReponse.Success)
                return Ok(serviceReponse);
            return BadRequest(serviceReponse);
        }


        [HttpPost("/login")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<ApiResponse<UserTokenDto>>> AuthenticateUserAsync([FromBody] UserLoginDto credencials)
        {
            var serviceReponse = await _userService.AuthenticateUserAsync(credencials.Username, credencials.Password);
            if (serviceReponse.Success)
                return Ok(serviceReponse);
            return BadRequest(serviceReponse);
        }

    }
}
