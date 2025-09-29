using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using LotusFive.Application.Authentication;
using LotusFive.Application.Authentication.Commands;
using Moq;
using Xunit;

namespace LotusFive.Application.UnitTests.Authentication;

public class AuthenticateUserCommandHandlerTests
{
    private readonly Mock<IUserCredentialValidator> _credentialValidatorMock = new();
    private readonly Mock<IJwtTokenGenerator> _tokenGeneratorMock = new();

    [Fact]
    public async Task Handle_ShouldReturnNull_WhenCredentialsAreInvalid()
    {
        // Arrange
        var handler = CreateHandler();
        var ignoredRoles = (IReadOnlyCollection<string>)new List<string>();
        _credentialValidatorMock
            .Setup(v => v.TryValidateCredentials("user", "wrong", out ignoredRoles))
            .Returns(false);

        var command = new AuthenticateUserCommand("user", "wrong");

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().BeNull();
        _tokenGeneratorMock.Verify(g => g.GenerateToken(It.IsAny<string>(), It.IsAny<IReadOnlyCollection<string>>()), Times.Never);
    }

    [Fact]
    public async Task Handle_ShouldReturnAuthenticationResult_WhenCredentialsAreValid()
    {
        // Arrange
        var roles = (IReadOnlyCollection<string>)new List<string> { "Admin" };
        var expected = new AuthenticationResult("token", System.DateTime.UtcNow.AddMinutes(5));
        var handler = CreateHandler();

        _credentialValidatorMock
            .Setup(v => v.TryValidateCredentials("user", "pass", out roles))
            .Returns(true);

        _tokenGeneratorMock
            .Setup(g => g.GenerateToken("user", roles))
            .Returns(expected);

        var command = new AuthenticateUserCommand("user", "pass");

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().Be(expected);
    }

    private AuthenticateUserCommandHandler CreateHandler() => new(_credentialValidatorMock.Object, _tokenGeneratorMock.Object);
}
