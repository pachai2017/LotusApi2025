using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using LotusFive.Application.Authentication;
using LotusFive.Application.Authentication.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IMediator mediator, ILogger<AuthController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthenticationResult>> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                _logger.LogWarning("Login request payload was null");
                return BadRequest();
            }

            _logger.LogInformation("Attempting to authenticate user {Username}", request.Username);
            var result = await _mediator.Send(new AuthenticateUserCommand(request.Username, request.Password), cancellationToken);
            if (result is null)
            {
                _logger.LogWarning("Authentication failed for user {Username}", request.Username);
                return Unauthorized();
            }

            _logger.LogInformation("Successfully authenticated user {Username}", request.Username);
            return Ok(result);
        }
    }

    public class LoginRequest
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
