using System.Collections.Generic;

namespace LotusFive.Application.Authentication
{
    public interface IJwtTokenGenerator
    {
        AuthenticationResult GenerateToken(string username, IReadOnlyCollection<string> roles);
    }
}
