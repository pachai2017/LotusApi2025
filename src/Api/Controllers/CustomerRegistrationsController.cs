using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerRegistrationsController : BaseEntityController<CustomerRegistration, string>
    {
        public CustomerRegistrationsController(IMediator mediator, ILogger<BaseEntityController<CustomerRegistration, string>> logger) : base(mediator, logger)
        {
        }
    }
}
