using System;
using System.Collections.Generic;
using LotusFive.Application.Common.Commands;
using LotusFive.Application.Common.Queries;
using LotusFive.Application.EmailOtpTransactions.Queries;
using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailOtpTransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EmailOtpTransactionsController> _logger;

        public EmailOtpTransactionsController(IMediator mediator, ILogger<EmailOtpTransactionsController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailOtpTransaction>>> GetAll(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching all email OTP transactions");
            var result = await _mediator.Send(new GetAllEntitiesQuery<EmailOtpTransaction>(), cancellationToken);
            _logger.LogInformation("Successfully fetched all email OTP transactions");
            return Ok(result);
        }

        [HttpGet("{emailId}/{otp}")]
        public async Task<ActionResult<EmailOtpTransaction>> GetById(string emailId, string otp, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching email OTP transaction for email {EmailId} and OTP {Otp}", emailId, otp);
            var entity = await _mediator.Send(new GetEmailOtpTransactionQuery(emailId, otp), cancellationToken);
            if (entity == null)
            {
                _logger.LogWarning("Email OTP transaction for email {EmailId} and OTP {Otp} was not found", emailId, otp);
                return NotFound();
            }

            _logger.LogInformation("Successfully fetched email OTP transaction for email {EmailId} and OTP {Otp}", emailId, otp);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<EmailOtpTransaction>> Create([FromBody] EmailOtpTransaction transaction, CancellationToken cancellationToken)
        {
            if (transaction == null)
            {
                _logger.LogWarning("Attempted to create email OTP transaction with null payload");
                return BadRequest();
            }

            _logger.LogInformation("Creating email OTP transaction for email {EmailId}", transaction.EmailId);
            var created = await _mediator.Send(new CreateEntityCommand<EmailOtpTransaction>(transaction), cancellationToken);
            _logger.LogInformation("Successfully created email OTP transaction for email {EmailId} and OTP {Otp}", created.EmailId, created.Otp);
            return CreatedAtAction(nameof(GetById), new { emailId = created.EmailId, otp = created.Otp }, created);
        }
    }
}
