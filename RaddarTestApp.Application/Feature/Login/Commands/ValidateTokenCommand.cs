using MediatR;
using System.ComponentModel.DataAnnotations;

namespace RaddarTestApp.Application.Feature.Login.Commands
{
    public record ValidateTokenCommand(
        [Required] string Token
    ) : IRequest<bool>;
}
