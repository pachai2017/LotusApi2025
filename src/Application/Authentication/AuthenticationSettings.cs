using System.Collections.Generic;

namespace LotusFive.Application.Authentication
{
    public class AuthenticationSettings
    {
        public string SecretKey { get; set; } = string.Empty;

        public string Issuer { get; set; } = string.Empty;

        public string Audience { get; set; } = string.Empty;

        public int TokenLifetimeMinutes { get; set; } = 60;

        public List<AuthenticationUser> Users { get; set; } = new();
    }

    public class AuthenticationUser
    {
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public List<string> Roles { get; set; } = new();
    }
}
