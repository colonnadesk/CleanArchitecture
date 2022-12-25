using Domain.Entities;

namespace Application.Common.Interfaces.Authenticaion
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
