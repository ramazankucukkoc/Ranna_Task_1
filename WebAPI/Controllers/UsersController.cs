
using Application.Features.Users.Commands;
using Application.Features.Users.Dtos;
using Application.Features.Users.Queries.GetByIdUserQuery;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserCommnad deleteUserCommnad)
        {
            DeletedUserDto deletedUserDto = await Mediator.Send(deleteUserCommnad);
            return Ok(deletedUserDto);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
        {
            UpdateUserDto deletedUserDto = await Mediator.Send(updateUserCommand);
            return Ok(deletedUserDto);
        }
        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetByIdUser([FromRoute] GetByIdUserQuery getByIdUserQuery)
        {
            GetByIdUserDto getByIdUserDto = await Mediator.Send(getByIdUserQuery);
            return Ok(getByIdUserDto);
        }
    }
}
