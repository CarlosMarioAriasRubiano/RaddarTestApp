using MediatR;
using RaddarTestApp.Domain.Ports;
using RaddarTestApp.Domain.Services;
using System.Security.Claims;

namespace RaddarTestApp.Application.Feature.Login.Commands
{
    public class ValidateTokenCommandHandler(
        IJwtGenerator jwtGenerator,
        LoginService loginService
    ) : IRequestHandler<ValidateTokenCommand, bool>
    {
        private readonly IJwtGenerator _jwtGenerator = jwtGenerator;
        private readonly LoginService _loginService = loginService;

        public async Task<bool> Handle(ValidateTokenCommand request, CancellationToken cancellationToken)
        {
            ClaimsPrincipal claims = _jwtGenerator.DeserializeToken(request.Token);

            return await _loginService.ValidateUserTokenAsync(claims.FindFirst("UserName")!.Value);
        }
    }
}
