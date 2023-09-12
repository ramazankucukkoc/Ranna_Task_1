using Application.Features.Auths.Command.Login;
using Application.Features.Auths.Command.Register;
using Application.Features.Auths.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthsController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new () { UserForLoginDto=userForLoginDto};
            LoggedDto loggedDto = await Mediator.Send(loginCommand);
            return Ok(loggedDto);
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto )
        {
            RegisterCommand registerCommand  = new (){ UserForRegisterDto = userForRegisterDto };
            RegisteredDto registeredDto = await Mediator.Send(registerCommand);
            return Ok(registeredDto);
        }

    }
}
