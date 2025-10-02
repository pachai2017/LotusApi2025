using System;
using LotusFive.Application.Common.Interfaces;
using LotusFive.Domain.Common;
using LotusFive.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LotusFive.Application.UnitTests.Common;

internal static class TestAppDbContextFactory
{
    public static TestAppDbContext Create()
    {
        var options = new DbContextOptionsBuilder<TestAppDbContext>()
            .UseInMemoryDatabase($"LotusFiveTests-{Guid.NewGuid()}")
            .Options;

        return new TestAppDbContext(options);
    }
}

internal sealed class TestAppDbContext : DbContext, IAppDbContext
{
    public TestAppDbContext(DbContextOptions<TestAppDbContext> options)
        : base(options)
    {
    }

    public DbSet<TestEntity> TestEntities => Set<TestEntity>();
    public DbSet<OtpTransaction> OtpTransactions => Set<OtpTransaction>();
    public DbSet<EmailOtpTransaction> EmailOtpTransactions => Set<EmailOtpTransaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TestEntity>().HasKey(e => e.Id);
        modelBuilder.Entity<OtpTransaction>().HasKey(e => new { e.MobileNo, e.Otp });
        modelBuilder.Entity<EmailOtpTransaction>().HasKey(e => new { e.EmailId, e.Otp });
    }
}

internal sealed class TestEntity : IEntity<int>
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
