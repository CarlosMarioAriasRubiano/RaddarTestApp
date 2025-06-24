using RaddarTestApp.Domain.Entities;
using System.Security.Claims;

namespace RaddarTestApp.Domain.Ports
{
    public interface IJwtGenerator
    {
        string GenerateToken(User user);
        ClaimsPrincipal DeserializeToken(string token);
    }
}
