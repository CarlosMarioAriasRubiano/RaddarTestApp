using MediatR;
using Microsoft.AspNetCore.Mvc;
using RaddarTestApp.Application.Feature.User.Commands;
using RaddarTestApp.Domain.Entities;

namespace RaddarTestApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController(
        IMediator mediator
    ) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<User> CreateUserAsync(
            [FromBody] CreateUserCommand command
        )
        {
            return await _mediator.Send(command);
        }
    }
}
