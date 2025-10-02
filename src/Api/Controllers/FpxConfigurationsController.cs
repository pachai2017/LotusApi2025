using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FpxConfigurationsController : BaseEntityController<FpxConfiguration, int>
    {
        public FpxConfigurationsController(IMediator mediator, ILogger<BaseEntityController<FpxConfiguration, int>> logger) : base(mediator, logger)
        {
        }
    }
}
