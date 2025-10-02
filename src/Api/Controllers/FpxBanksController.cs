using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FpxBanksController : BaseEntityController<FpxBank, int>
    {
        public FpxBanksController(IMediator mediator, ILogger<BaseEntityController<FpxBank, string>> logger) : base(mediator, logger)
        {
        }
    }
}
