using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NationalitiesController : BaseEntityController<Nationality, int>
    {
        public NationalitiesController(IMediator mediator) : base(mediator)
        {
        }
    }
}
