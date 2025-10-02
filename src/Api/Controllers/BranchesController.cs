using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchesController : BaseEntityController<Branch, string>
    {
        public BranchesController(IMediator mediator, ILogger<BaseEntityController<Branch, string>> logger) : base(mediator, logger)
        {
        }
    }
}
