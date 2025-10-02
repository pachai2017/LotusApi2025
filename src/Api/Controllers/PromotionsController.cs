using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionsController : BaseEntityController<Promotion, string>
    {
        public PromotionsController(IMediator mediator, ILogger<BaseEntityController<Promotion, string>> logger) : base(mediator, logger)
        {
        }
    }
}
