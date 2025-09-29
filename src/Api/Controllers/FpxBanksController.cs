using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FpxBanksController : BaseEntityController<FpxBank, int>
    {
        public FpxBanksController(IMediator mediator) : base(mediator)
        {
        }
    }
}
