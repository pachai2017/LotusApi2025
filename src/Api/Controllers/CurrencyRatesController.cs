using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyRatesController : BaseEntityController<CurrencyRate, string>
    {
        public CurrencyRatesController(IMediator mediator, ILogger<BaseEntityController<CurrencyRate, string>> logger) : base(mediator, logger)
        {
        }
    }
}
