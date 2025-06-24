using RaddarTestApp.Domain.Dtos;
using RaddarTestApp.Domain.Entities;
using RaddarTestApp.Domain.Enums;
using RaddarTestApp.Domain.Exceptions;
using RaddarTestApp.Domain.Helpers;
using RaddarTestApp.Domain.Ports;

namespace RaddarTestApp.Domain.Services
{
    [DomainService]
    public class LoginService(
        IQueryDapper queryDapper,
        IJwtGenerator jwtGenerator
    )
    {
        private readonly IQueryDapper _queryDapper = queryDapper;
        private readonly IJwtGenerator _jwtGenerator = jwtGenerator;

        public async Task<AccesTokenDto> LoginAsync(
            string userName,
            string password
        )
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                throw new AppException(MessagesExceptions.UserOrPassEmpty);
            }

            User user = await _queryDapper.QuerySingleAsync<User>(
                ItemQueryConstants.GetUserByUserNameAndPassword.GetDescription(),
                new { userName, password }
            ) ?? throw new AppException(MessagesExceptions.DontExistsUserToken);

            return new(
                _jwtGenerator.GenerateToken(user)
            );
        }

        public async Task<bool> ValidateUserTokenAsync(string userName)
        {
            _ = await _queryDapper.QuerySingleAsync<User>(
                ItemQueryConstants.GetUserByUserName.GetDescription(),
                new { userName }
            ) ?? throw new AppException(MessagesExceptions.DontExistsUserToken);

            return true;
        }
    }
}
