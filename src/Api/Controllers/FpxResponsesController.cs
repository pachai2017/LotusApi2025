using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FpxResponsesController : BaseEntityController<FpxResponse, string>
    {
        public FpxResponsesController(IMediator mediator, ILogger<BaseEntityController<FpxResponse, string>> logger) : base(mediator, logger)
        {
        }
    }
}
