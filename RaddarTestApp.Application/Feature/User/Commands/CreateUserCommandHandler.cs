using MediatR;
using RaddarTestApp.Domain.Services;

namespace RaddarTestApp.Application.Feature.User.Commands
{
    public class CreateUserCommandHandler(UserService userService) : IRequestHandler<CreateUserCommand, Domain.Entities.User>
    {
        private readonly UserService _userService = userService;

        public async Task<Domain.Entities.User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _userService.ValidatePassword(request.Password, request.ConfirmPassword);

            Domain.Entities.User user = new()
            {
                Name = request.Name,
                Phone = request.Phone,
                Address = request.Address,
                Email = request.Email,
                UserName = request.UserName,
                Password = request.Password
            };

            return await _userService.CreateUserAsync(user);
        }
    }
}
