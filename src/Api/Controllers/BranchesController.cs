using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchesController : BaseEntityController<Branch, string>
    {
        public BranchesController(IMediator mediator) : base(mediator)
        {
        }
    }
}
