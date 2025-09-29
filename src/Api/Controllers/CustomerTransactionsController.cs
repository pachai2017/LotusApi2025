using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerTransactionsController : BaseEntityController<CustomerTransaction, string>
    {
        public CustomerTransactionsController(IMediator mediator) : base(mediator)
        {
        }
    }
}
