using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionsController : BaseEntityController<Promotion, string>
    {
        public PromotionsController(IMediator mediator) : base(mediator)
        {
        }
    }
}
