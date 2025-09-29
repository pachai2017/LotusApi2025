using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using LotusFive.Domain.Entities;
using Xunit;

namespace LotusFive.Api.IntegrationTests;

public class BranchesEndpointTests : IClassFixture<Infrastructure.TestingWebApplicationFactory>
{
    private readonly Infrastructure.TestingWebApplicationFactory _factory;

    public BranchesEndpointTests(Infrastructure.TestingWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetBranches_ShouldReturnSeededBranches()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/api/Branches");

        // Assert
        response.EnsureSuccessStatusCode();
        var branches = await response.Content.ReadFromJsonAsync<Branch[]>();
        branches.Should().NotBeNull().And.HaveCountGreaterThan(0);
        branches!.Should().Contain(b => b.Id == "HQ");
    }

    [Fact]
    public async Task GetBranchById_ShouldReturnSingleBranch()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/api/Branches/HQ");

        // Assert
        response.EnsureSuccessStatusCode();
        var branch = await response.Content.ReadFromJsonAsync<Branch>();
        branch.Should().NotBeNull();
        branch!.Id.Should().Be("HQ");
    }
}
