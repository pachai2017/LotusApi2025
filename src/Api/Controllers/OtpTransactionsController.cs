using System;
using System.Collections.Generic;
using LotusFive.Application.Common.Commands;
using LotusFive.Application.Common.Queries;
using LotusFive.Application.OtpTransactions.Queries;
using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OtpTransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OtpTransactionsController> _logger;

        public OtpTransactionsController(IMediator mediator, ILogger<OtpTransactionsController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OtpTransaction>>> GetAll(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching all OTP transactions");
            var result = await _mediator.Send(new GetAllEntitiesQuery<OtpTransaction>(), cancellationToken);
            _logger.LogInformation("Successfully fetched all OTP transactions");
            return Ok(result);
        }

        [HttpGet("{mobileNo}/{otp}")]
        public async Task<ActionResult<OtpTransaction>> GetById(string mobileNo, string otp, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching OTP transaction for mobile {MobileNo} and OTP {Otp}", mobileNo, otp);
            var entity = await _mediator.Send(new GetOtpTransactionQuery(mobileNo, otp), cancellationToken);
            if (entity == null)
            {
                _logger.LogWarning("OTP transaction for mobile {MobileNo} and OTP {Otp} was not found", mobileNo, otp);
                return NotFound();
            }

            _logger.LogInformation("Successfully fetched OTP transaction for mobile {MobileNo} and OTP {Otp}", mobileNo, otp);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<OtpTransaction>> Create([FromBody] OtpTransaction transaction, CancellationToken cancellationToken)
        {
            if (transaction == null)
            {
                _logger.LogWarning("Attempted to create OTP transaction with null payload");
                return BadRequest();
            }

            _logger.LogInformation("Creating OTP transaction for mobile {MobileNo}", transaction.MobileNo);
            var created = await _mediator.Send(new CreateEntityCommand<OtpTransaction>(transaction), cancellationToken);
            _logger.LogInformation("Successfully created OTP transaction for mobile {MobileNo} and OTP {Otp}", created.MobileNo, created.Otp);
            return CreatedAtAction(nameof(GetById), new { mobileNo = created.MobileNo, otp = created.Otp }, created);
        }
    }
}
