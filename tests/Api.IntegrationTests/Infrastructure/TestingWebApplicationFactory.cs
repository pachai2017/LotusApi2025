using System.Collections.Generic;
using System.Linq;
using LotusFive.Application.Common.Interfaces;
using LotusFive.Domain.Entities;
using LotusFive.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LotusFive.Api.IntegrationTests.Infrastructure;

public class TestingWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Development");

        builder.ConfigureAppConfiguration((context, config) =>
        {
            var settings = new Dictionary<string, string?>
            {
                ["Authentication:SecretKey"] = "integration-test-secret",
                ["Authentication:Issuer"] = "TestIssuer",
                ["Authentication:Audience"] = "TestAudience",
                ["ConnectionStrings:Default"] = "UseInMemoryDatabase"
            };

            config.AddInMemoryCollection(settings!);
        });

        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<AppDbContext>));
            services.RemoveAll<AppDbContext>();
            services.RemoveAll<IAppDbContext>();

            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("LotusApiTests"));
            services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = TestAuthHandler.SchemeName;
                options.DefaultChallengeScheme = TestAuthHandler.SchemeName;
            }).AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(TestAuthHandler.SchemeName, _ => { });

            using var scope = services.BuildServiceProvider().CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            context.Database.EnsureCreated();
            SeedDatabase(context);
        });
    }

    private static void SeedDatabase(AppDbContext context)
    {
        if (context.Branches.Any())
        {
            return;
        }

        context.Branches.AddRange(
            new Branch { Id = "HQ", Name = "Headquarters", Address = "123 Main St" },
            new Branch { Id = "KL", Name = "Kuala Lumpur", Address = "Kuala Lumpur" }
        );

        context.SaveChanges();
    }
}
