using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferFeesController : BaseEntityController<TransferFee, string>
    {
        public TransferFeesController(IMediator mediator) : base(mediator)
        {
        }
    }
}
