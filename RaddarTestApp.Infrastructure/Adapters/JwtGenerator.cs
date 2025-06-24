using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RaddarTestApp.Domain.Entities;
using RaddarTestApp.Domain.Exceptions;
using RaddarTestApp.Domain.Ports;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RaddarTestApp.Infrastructure.Adapters
{
    public class JwtGenerator(IConfiguration config) : IJwtGenerator
    {
        private readonly SymmetricSecurityKey _key = new(Encoding.UTF8.GetBytes(config.GetValue<string>("JWT_SECRET_KEY")!));

        public ClaimsPrincipal DeserializeToken(string token)
        {
            token = token["Bearer ".Length..].Trim();
            var tokenHandler = new JwtSecurityTokenHandler();

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _key,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true
            }, out SecurityToken validatedToken);

            return validatedToken is JwtSecurityToken jwtToken
                ? new ClaimsPrincipal(new ClaimsIdentity(jwtToken.Claims))
                : throw new AppException(MessagesExceptions.InvalidToken);
        }

        public string GenerateToken(User user)
        {
            List<Claim> claims =
            [
                new("Id", $"{user.Id}"),
                new("UserName", $"{user.UserName}")
            ];

            var expiracion = DateTime.UtcNow.AddHours(24);
            SigningCredentials creds = new(_key, SecurityAlgorithms.HmacSha512Signature);

            JwtSecurityToken securityToken = new(issuer: null, audience: null, claims: claims, expires: expiracion, signingCredentials: creds);

            JwtSecurityTokenHandler tokenHandler = new();

            return tokenHandler.WriteToken(securityToken);
        }
    }
}
