using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampaignsController : BaseEntityController<Campaign, string>
    {
        public CampaignsController(IMediator mediator, ILogger<BaseEntityController<Campaign, string>> logger) : base(mediator, logger)
        {
        }
    }
}
