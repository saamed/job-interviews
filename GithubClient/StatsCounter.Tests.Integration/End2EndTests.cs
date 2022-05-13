using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace StatsCounter.Tests.Integration
{
    public class End2EndTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public End2EndTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Fact]
        public async Task CanReachGitHub()
        {
            // given
            var client = _factory.CreateClient();
            
            // when
            var response = await client.GetAsync("repositories/octocat");

            // then
            response.IsSuccessStatusCode.Should().BeTrue();
        }
    }
}