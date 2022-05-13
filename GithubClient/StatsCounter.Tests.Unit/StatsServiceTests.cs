using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using StatsCounter.Models;
using StatsCounter.Services;
using Xunit;

namespace StatsCounter.Tests.Unit
{
    public class StatsServiceTests
    {
        private readonly Mock<IGitHubService> _gitHubService;
        private readonly IStatsService _statsService;

        public StatsServiceTests()
        {
            _gitHubService = new Mock<IGitHubService>();
            _statsService = new StatsService(_gitHubService.Object);
        }
        
        [Fact]
        public async Task ShouldReturnOwner()
        {
            // given
            _gitHubService
                .Setup(s => s.GetRepositoryInfosByOwnerAsync(It.IsAny<string>()))
                .ReturnsAsync(
                    new List<RepositoryInfo>
                    {
                        new RepositoryInfo { Id = 1, Name = "name" },
                        new RepositoryInfo { Id = 2, Name = "name" }
                    });

            // when
            var result = await _statsService.GetRepositoryStatsByOwnerAsync("owner");

            // then
            result.Owner.Should().Be("owner");
        }

        [Fact]
        public async Task ShouldCalculateStargazersAverage()
        {
            // given
            _gitHubService
                .Setup(s => s.GetRepositoryInfosByOwnerAsync(It.IsAny<string>()))
                .ReturnsAsync(
                    new List<RepositoryInfo>
                    {
                        new RepositoryInfo { Id = 1, Name = "name", StargazersCount = 10 },
                        new RepositoryInfo { Id = 2, Name = "name", StargazersCount = 20 }
                    });

            // when
            var result = await _statsService.GetRepositoryStatsByOwnerAsync("owner");

            // then
            result.AvgStargazers.Should().BeApproximately(15.0, 1e-6);
        }
        
        [Fact]
        public async Task ShouldCalculateWatchersAverage()
        {
            // given
            _gitHubService
                .Setup(s => s.GetRepositoryInfosByOwnerAsync(It.IsAny<string>()))
                .ReturnsAsync(
                    new List<RepositoryInfo>
                    {
                        new RepositoryInfo { Id = 1, Name = "name", WatchersCount = 10 },
                        new RepositoryInfo { Id = 2, Name = "name", WatchersCount = 20 }
                    });

            // when
            var result = await _statsService.GetRepositoryStatsByOwnerAsync("owner");

            // then
            result.AvgWatchers.Should().BeApproximately(15.0, 1e-6);
        }
        
        [Fact]
        public async Task ShouldCalculateForksAverage()
        {
            // given
            _gitHubService
                .Setup(s => s.GetRepositoryInfosByOwnerAsync(It.IsAny<string>()))
                .ReturnsAsync(
                    new List<RepositoryInfo>
                    {
                        new RepositoryInfo { Id = 1, Name = "name", ForksCount = 10 },
                        new RepositoryInfo { Id = 2, Name = "name", ForksCount = 20 }
                    });

            // when
            var result = await _statsService.GetRepositoryStatsByOwnerAsync("owner");

            // then
            result.AvgForks.Should().BeApproximately(15.0, 1e-6);
        }
        
        [Fact]
        public async Task ShouldCalculateSizeAverage()
        {
            // given
            _gitHubService
                .Setup(s => s.GetRepositoryInfosByOwnerAsync(It.IsAny<string>()))
                .ReturnsAsync(
                    new List<RepositoryInfo>
                    {
                        new RepositoryInfo { Id = 1, Name = "name", Size = 10 },
                        new RepositoryInfo { Id = 2, Name = "name", Size = 20 }
                    });

            // when
            var result = await _statsService.GetRepositoryStatsByOwnerAsync("owner");

            // then
            result.AvgSize.Should().BeApproximately(15.0, 1e-6);
        }
    }
}