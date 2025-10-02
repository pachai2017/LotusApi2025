using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerTransactionsController : BaseEntityController<CustomerTransaction, string>
    {
        public CustomerTransactionsController(IMediator mediator, ILogger<BaseEntityController<CustomerTransaction, string>> logger) : base(mediator, logger)
        {
        }
    }
}
