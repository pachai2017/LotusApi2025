using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : BaseEntityController<Country, int>
    {
        public CountriesController(IMediator mediator, ILogger<BaseEntityController<Country, int>> logger) : base(mediator, logger)
        {
        }
    }
}
