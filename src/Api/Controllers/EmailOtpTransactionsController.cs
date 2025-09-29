using System.Collections.Generic;
using LotusFive.Application.Common.Commands;
using LotusFive.Application.Common.Queries;
using LotusFive.Application.EmailOtpTransactions.Queries;
using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailOtpTransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmailOtpTransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailOtpTransaction>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllEntitiesQuery<EmailOtpTransaction>(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("{emailId}/{otp}")]
        public async Task<ActionResult<EmailOtpTransaction>> GetById(string emailId, string otp, CancellationToken cancellationToken)
        {
            var entity = await _mediator.Send(new GetEmailOtpTransactionQuery(emailId, otp), cancellationToken);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<EmailOtpTransaction>> Create([FromBody] EmailOtpTransaction transaction, CancellationToken cancellationToken)
        {
            var created = await _mediator.Send(new CreateEntityCommand<EmailOtpTransaction>(transaction), cancellationToken);
            return CreatedAtAction(nameof(GetById), new { emailId = created.EmailId, otp = created.Otp }, created);
        }
    }
}
