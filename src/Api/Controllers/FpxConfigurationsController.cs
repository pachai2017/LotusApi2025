using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FpxConfigurationsController : BaseEntityController<FpxConfiguration, int>
    {
        public FpxConfigurationsController(IMediator mediator) : base(mediator)
        {
        }
    }
}
