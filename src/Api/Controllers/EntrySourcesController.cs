using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntrySourcesController : BaseEntityController<EntrySource, int>
    {
        public EntrySourcesController(IMediator mediator, ILogger<BaseEntityController<EntrySource, int>> logger) : base(mediator, logger)
        {
        }
    }
}
