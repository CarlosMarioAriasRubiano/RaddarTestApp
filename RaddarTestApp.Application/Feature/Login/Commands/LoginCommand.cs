using MediatR;
using RaddarTestApp.Domain.Dtos;
using System.ComponentModel.DataAnnotations;

namespace RaddarTestApp.Application.Feature.Login.Commands
{
    public record LoginCommand(
        [Required] string UserName,
        [Required] string Password
    ) : IRequest<AccesTokenDto>;
}
