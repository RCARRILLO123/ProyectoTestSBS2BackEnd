using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Features.EntidadGubernamental.Commands;
using Test.Application.Features.EntidadGubernamental.Queries;

namespace Test.WebApi.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class EntidadGubernamentalController : BaseApiController
    {
         [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetEntidadGubernamentalAllQuery filter)
        {
            return Ok(await Mediator.Send(filter));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateEntidadGubernamentalCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdateEntidadGubernamentalCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet("Delete")]
        public async Task<IActionResult> Delete([FromQuery]  DeleteEntidadGubernamentalCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
