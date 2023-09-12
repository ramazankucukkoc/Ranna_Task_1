using Application.Features.Adminsrators.Command.CreateAdmin;
using Application.Features.Adminsrators.Command.DeleteAdmin;
using Application.Features.Adminsrators.Command.UpdateAdmin;
using Application.Features.Adminsrators.Dtos;
using Application.Features.Adminsrators.Queries.GetById;
using Application.Features.Adminsrators.Queries.GetList;
using Application.Features.Users.Commands;
using Application.Features.Users.Dtos;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAdminCommand createAdminCommand )
        {
            CreateAdminDto createAdminDto  = await Mediator.Send(createAdminCommand);
            return Ok(createAdminDto);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAdminCommand updateAdminCommand )
        {
            UpdateAdminDto updateAdminDto = await Mediator.Send(updateAdminCommand);
            return Ok(updateAdminDto);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteAdminCommand deleteAdminCommand)
        {
            DeleteAdminDto deleteAdminDto = await Mediator.Send(deleteAdminCommand);
            return Ok(deleteAdminDto);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllList([FromQuery] PageRequest pageRequest)
        {
            GetListAdminQuery getListAdminQuery = new() { PageRequest = pageRequest };

            GetListResponse<AdminListDto> adminDto = await Mediator.Send(getListAdminQuery);
            return Ok(adminDto);
        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdAdminQuery getByIdAdminQuery )
        {
            AdminListDto adminListDto = await Mediator.Send(getByIdAdminQuery);  
            return Ok(adminListDto);
        }
    }
}
