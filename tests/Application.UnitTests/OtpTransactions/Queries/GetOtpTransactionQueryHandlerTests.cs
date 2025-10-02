using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using LotusFive.Application.OtpTransactions.Queries;
using LotusFive.Application.UnitTests.Common;
using LotusFive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LotusFive.Application.UnitTests.OtpTransactions.Queries;

public class GetOtpTransactionQueryHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnNull_WhenTransactionDoesNotExist()
    {
        await using var context = TestAppDbContextFactory.Create();
        var handler = new GetOtpTransactionQueryHandler(context);

        var result = await handler.Handle(new GetOtpTransactionQuery("0123456789", "123456"), CancellationToken.None);

        result.Should().BeNull();
    }

    [Fact]
    public async Task Handle_ShouldReturnTransaction_WhenFound()
    {
        await using var context = TestAppDbContextFactory.Create();
        var transaction = new OtpTransaction
        {
            MobileNo = "0123456789",
            Otp = "654321",
            Status = 1,
            ExpiryDate = DateTime.UtcNow.AddMinutes(5)
        };
        context.OtpTransactions.Add(transaction);
        await context.SaveChangesAsync();
        var handler = new GetOtpTransactionQueryHandler(context);

        var result = await handler.Handle(new GetOtpTransactionQuery("0123456789", "654321"), CancellationToken.None);

        result.Should().NotBeNull();
        result!.Status.Should().Be(1);
    }
}
