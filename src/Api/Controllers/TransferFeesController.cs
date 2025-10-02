using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferFeesController : BaseEntityController<TransferFee, string>
    {
        public TransferFeesController(IMediator mediator, ILogger<BaseEntityController<TransferFee, string>> logger) : base(mediator, logger)
        {
        }
    }
}
