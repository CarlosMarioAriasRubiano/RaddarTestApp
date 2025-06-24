using MediatR;
using Microsoft.AspNetCore.Mvc;
using RaddarTestApp.Application.Feature.Login.Commands;
using RaddarTestApp.Domain.Dtos;

namespace RaddarTestApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class LoginController(
        IMediator mediator
    ) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<AccesTokenDto> LoginAsync(
            [FromBody] LoginCommand command
        )
        {
            return await _mediator.Send(command);
        }
    }
}
