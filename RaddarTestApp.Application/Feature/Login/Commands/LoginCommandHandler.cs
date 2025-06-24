using MediatR;
using RaddarTestApp.Domain.Dtos;
using RaddarTestApp.Domain.Services;

namespace RaddarTestApp.Application.Feature.Login.Commands
{
    public class LoginCommandHandler(LoginService loginService) : IRequestHandler<LoginCommand, AccesTokenDto>
    {
        private readonly LoginService _loginService = loginService;

        public async Task<AccesTokenDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _loginService.LoginAsync(request.UserName, request.Password);
        }
    }
}
