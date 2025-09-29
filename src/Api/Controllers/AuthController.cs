using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using LotusFive.Application.Authentication;
using LotusFive.Application.Authentication.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthenticationResult>> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new AuthenticateUserCommand(request.Username, request.Password), cancellationToken);
            if (result is null)
            {
                return Unauthorized();
            }

            return Ok(result);
        }
    }

    public record LoginRequest(
        [property: Required] string Username,
        [property: Required] string Password);
}
