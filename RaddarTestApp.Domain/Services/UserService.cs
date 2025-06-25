using RaddarTestApp.Domain.Entities;
using RaddarTestApp.Domain.Enums;
using RaddarTestApp.Domain.Exceptions;
using RaddarTestApp.Domain.Helpers;
using RaddarTestApp.Domain.Ports;

namespace RaddarTestApp.Domain.Services
{
    [DomainService]
    public class UserService(
        IGenericRepository<User> userRepository,
        IQueryDapper queryDapper
    )
    {
        private readonly IGenericRepository<User> _userRepository = userRepository;
        private readonly IQueryDapper _queryDapper = queryDapper;

        public void ValidatePassword(string password, string confirmPassword)
        {
            password.ValidateIsNullOrEmpty(nameof(password));
            confirmPassword.ValidateIsNullOrEmpty(nameof(confirmPassword));

            if (!password.Equals(confirmPassword))
            {
                throw new AppException(MessagesExceptions.NotMatchPassword);
            }
        }

        public async Task<User> CreateUserAsync(User user)
        {
            user.ValidateNullObject();
            user.Name.ValidateIsNullOrEmpty(nameof(user.Name));
            user.Email.ValidateIsNullOrEmpty(nameof(user.Email));
            user.UserName.ValidateIsNullOrEmpty(nameof(user.UserName));
            user.Password.ValidateIsNullOrEmpty(nameof(user.Password));

            User userValidation = await _queryDapper.QuerySingleAsync<User>(
                ItemQueryConstants.GetUserByUserName.GetDescription(),
                new { user.UserName }
            );

            if (userValidation != null)
            {
                throw new AppException(MessagesExceptions.UserExistsWithUserName);
            }

            userValidation = await _queryDapper.QuerySingleAsync<User>(
                ItemQueryConstants.GetUserByEmail.GetDescription(),
                new { user.Email }
            );

            if (userValidation != null)
            {
                throw new AppException(MessagesExceptions.UserExistsWithEmail);
            }

            return await _userRepository.CreateAsync(user);
        }
    }
}
