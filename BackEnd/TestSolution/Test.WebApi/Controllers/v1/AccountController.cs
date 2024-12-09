using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Features.Usuario.Commands;

namespace Test.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AccountController : BaseApiController
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Auth(AuthenticateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
