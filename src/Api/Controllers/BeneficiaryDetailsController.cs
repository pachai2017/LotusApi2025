using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BeneficiaryDetailsController : BaseEntityController<BeneficiaryDetail, string>
    {
        public BeneficiaryDetailsController(IMediator mediator) : base(mediator)
        {
        }
    }
}
