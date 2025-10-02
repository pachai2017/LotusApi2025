using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NationalitiesController : BaseEntityController<Nationality, int>
    {
        public NationalitiesController(IMediator mediator, ILogger<BaseEntityController<Nationality, int>> logger) : base(mediator, logger)
        {
        }
    }
}
