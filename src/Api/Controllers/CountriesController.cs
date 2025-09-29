using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : BaseEntityController<Country, int>
    {
        public CountriesController(IMediator mediator) : base(mediator)
        {
        }
    }
}
