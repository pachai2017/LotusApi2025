using System;
using System.Collections.Generic;
using System.Linq;
using LotusFive.Application.Authentication;
using Microsoft.Extensions.Options;

namespace LotusFive.Infrastructure.Authentication
{
    public class InMemoryUserCredentialValidator : IUserCredentialValidator
    {
        private readonly IReadOnlyDictionary<string, (string Password, IReadOnlyCollection<string> Roles)> _users;

        public InMemoryUserCredentialValidator(IOptions<AuthenticationSettings> options)
        {
            var settings = options.Value ?? throw new ArgumentNullException(nameof(options));
            _users = (settings.Users ?? new List<AuthenticationUser>())
                .Where(user => !string.IsNullOrWhiteSpace(user.Username))
                .ToDictionary(
                    user => user.Username,
                    user =>
                    {
                        var roles = (user.Roles ?? new List<string>())
                            .Where(role => !string.IsNullOrWhiteSpace(role))
                            .Distinct(StringComparer.OrdinalIgnoreCase)
                            .ToArray();
                        return (user.Password ?? string.Empty, (IReadOnlyCollection<string>)roles);
                    },
                    StringComparer.OrdinalIgnoreCase);
        }

        public bool TryValidateCredentials(string username, string password, out IReadOnlyCollection<string> roles)
        {
            roles = Array.Empty<string>();
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            if (!_users.TryGetValue(username, out var user) || !string.Equals(user.Password, password, StringComparison.Ordinal))
            {
                return false;
            }

            roles = user.Roles;
            return true;
        }
    }
}
