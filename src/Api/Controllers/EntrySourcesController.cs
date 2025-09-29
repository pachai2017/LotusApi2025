using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntrySourcesController : BaseEntityController<EntrySource, int>
    {
        public EntrySourcesController(IMediator mediator) : base(mediator)
        {
        }
    }
}
