using MediatR;
using System.ComponentModel.DataAnnotations;

namespace RaddarTestApp.Application.Feature.User.Commands
{
    public record CreateUserCommand(
        [Required] string Name,
        string Phone,
        string Address,
        [Required] string Email,
        [Required] string UserName,
        [Required] string Password,
        [Required] string ConfirmPassword
    ) : IRequest<Domain.Entities.User>;
}
