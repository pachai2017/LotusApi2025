using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BeneficiaryDetailsController : BaseEntityController<BeneficiaryDetail, string>
    {
        public BeneficiaryDetailsController(IMediator mediator, ILogger<BaseEntityController<BeneficiaryDetail, string>> logger) : base(mediator, logger)
        {
        }
    }
}
