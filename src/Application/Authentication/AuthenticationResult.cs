using System;

namespace LotusFive.Application.Authentication
{
    public record AuthenticationResult(string Token, DateTime ExpiresAtUtc);
}
