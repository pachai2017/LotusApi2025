using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using LotusFive.Application.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LotusFive.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly AuthenticationSettings _settings;

        public JwtTokenGenerator(IOptions<AuthenticationSettings> options)
        {
            _settings = options.Value ?? throw new ArgumentNullException(nameof(options));
            if (string.IsNullOrWhiteSpace(_settings.SecretKey))
            {
                throw new InvalidOperationException("Authentication secret key is not configured.");
            }
        }

        public AuthenticationResult GenerateToken(string username, IReadOnlyCollection<string> roles)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, username)
            };

            if (roles != null && roles.Count > 0)
            {
                claims.AddRange(roles.Where(role => !string.IsNullOrWhiteSpace(role))
                    .Select(role => new Claim(ClaimTypes.Role, role)));
            }

            var lifetimeMinutes = _settings.TokenLifetimeMinutes > 0 ? _settings.TokenLifetimeMinutes : 60;
            var expires = DateTime.UtcNow.AddMinutes(lifetimeMinutes);

            var token = new JwtSecurityToken(
                issuer: string.IsNullOrWhiteSpace(_settings.Issuer) ? null : _settings.Issuer,
                audience: string.IsNullOrWhiteSpace(_settings.Audience) ? null : _settings.Audience,
                claims: claims,
                expires: expires,
                signingCredentials: credentials);

            var handler = new JwtSecurityTokenHandler();
            var tokenString = handler.WriteToken(token);

            return new AuthenticationResult(tokenString, expires);
        }
    }
}
