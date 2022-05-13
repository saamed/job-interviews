using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using StatsCounter.Services;
using Xunit;

namespace StatsCounter.Tests.Unit
{
    public class StartupExtensionsTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public StartupExtensionsTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public void ShouldResolveGitHubService()
        {
            _factory.CreateClient(); // dummy call to initialize _factory.Server
            using (var scope = _factory.Server.Host.Services.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<IGitHubService>();
                service.Should().NotBeNull();
            }
        }
    }
}