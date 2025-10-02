using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using LotusFive.Application.EmailOtpTransactions.Queries;
using LotusFive.Application.UnitTests.Common;
using LotusFive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LotusFive.Application.UnitTests.EmailOtpTransactions.Queries;

public class GetEmailOtpTransactionQueryHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnNull_WhenTransactionDoesNotExist()
    {
        await using var context = TestAppDbContextFactory.Create();
        var handler = new GetEmailOtpTransactionQueryHandler(context);

        var result = await handler.Handle(new GetEmailOtpTransactionQuery("user@example.com", "111111"), CancellationToken.None);

        result.Should().BeNull();
    }

    [Fact]
    public async Task Handle_ShouldReturnTransaction_WhenFound()
    {
        await using var context = TestAppDbContextFactory.Create();
        var transaction = new EmailOtpTransaction
        {
            EmailId = "user@example.com",
            Otp = "999999",
            Status = 1,
            ExpiryDate = DateTime.UtcNow.AddMinutes(3)
        };
        context.EmailOtpTransactions.Add(transaction);
        await context.SaveChangesAsync();
        var handler = new GetEmailOtpTransactionQueryHandler(context);

        var result = await handler.Handle(new GetEmailOtpTransactionQuery("user@example.com", "999999"), CancellationToken.None);

        result.Should().NotBeNull();
        result!.ExpiryDate.Should().Be(transaction.ExpiryDate);
    }
}
