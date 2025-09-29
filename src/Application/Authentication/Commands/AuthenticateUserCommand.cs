using System.Threading;
using System.Threading.Tasks;
using LotusFive.Application.Authentication;
using MediatR;

namespace LotusFive.Application.Authentication.Commands
{
    public record AuthenticateUserCommand(string Username, string Password) : IRequest<AuthenticationResult?>;

    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, AuthenticationResult?>
    {
        private readonly IUserCredentialValidator _credentialValidator;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public AuthenticateUserCommandHandler(
            IUserCredentialValidator credentialValidator,
            IJwtTokenGenerator tokenGenerator)
        {
            _credentialValidator = credentialValidator;
            _tokenGenerator = tokenGenerator;
        }

        public Task<AuthenticationResult?> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            if (!_credentialValidator.TryValidateCredentials(request.Username, request.Password, out var roles))
            {
                return Task.FromResult<AuthenticationResult?>(null);
            }

            var result = _tokenGenerator.GenerateToken(request.Username, roles);
            return Task.FromResult<AuthenticationResult?>(result);
        }
    }
}
