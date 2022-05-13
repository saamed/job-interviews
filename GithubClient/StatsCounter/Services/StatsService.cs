using System.Linq;
using System.Threading.Tasks;
using StatsCounter.Models;

namespace StatsCounter.Services
{
    public interface IStatsService
    {
        Task<RepositoryStats> GetRepositoryStatsByOwnerAsync(string owner);
    }

    public class StatsService : IStatsService
    {
        private readonly IGitHubService _gitHubService;

        public StatsService(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        public async Task<RepositoryStats> GetRepositoryStatsByOwnerAsync(string owner)
        {
            var data = await _gitHubService.GetRepositoryInfosByOwnerAsync(owner).ConfigureAwait(false); ;

            return new RepositoryStats()
            {
                AvgForks = data.Average(x => x.ForksCount),
                AvgSize = data.Average(x => x.Size),
                AvgStargazers = data.Average(x => x.StargazersCount),
                AvgWatchers = data.Average(x => x.WatchersCount),
                Owner = owner
            };
        }
    }
}