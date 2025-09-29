using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyRatesController : BaseEntityController<CurrencyRate, string>
    {
        public CurrencyRatesController(IMediator mediator) : base(mediator)
        {
        }
    }
}
