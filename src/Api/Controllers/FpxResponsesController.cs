using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FpxResponsesController : BaseEntityController<FpxResponse, string>
    {
        public FpxResponsesController(IMediator mediator) : base(mediator)
        {
        }
    }
}
