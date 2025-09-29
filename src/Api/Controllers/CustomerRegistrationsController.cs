using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerRegistrationsController : BaseEntityController<CustomerRegistration, string>
    {
        public CustomerRegistrationsController(IMediator mediator) : base(mediator)
        {
        }
    }
}
