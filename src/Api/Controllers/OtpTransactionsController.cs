using System.Collections.Generic;
using LotusFive.Application.Common.Commands;
using LotusFive.Application.Common.Queries;
using LotusFive.Application.OtpTransactions.Queries;
using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OtpTransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OtpTransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OtpTransaction>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllEntitiesQuery<OtpTransaction>(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("{mobileNo}/{otp}")]
        public async Task<ActionResult<OtpTransaction>> GetById(string mobileNo, string otp, CancellationToken cancellationToken)
        {
            var entity = await _mediator.Send(new GetOtpTransactionQuery(mobileNo, otp), cancellationToken);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<OtpTransaction>> Create([FromBody] OtpTransaction transaction, CancellationToken cancellationToken)
        {
            var created = await _mediator.Send(new CreateEntityCommand<OtpTransaction>(transaction), cancellationToken);
            return CreatedAtAction(nameof(GetById), new { mobileNo = created.MobileNo, otp = created.Otp }, created);
        }
    }
}
