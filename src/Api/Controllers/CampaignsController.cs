using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampaignsController : BaseEntityController<Campaign, string>
    {
        public CampaignsController(IMediator mediator) : base(mediator)
        {
        }
    }
}
