using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StatsCounter.Extensions;
using StatsCounter.Models;

namespace StatsCounter.Services
{
    public interface IGitHubService
    {
        Task<IEnumerable<RepositoryInfo>> GetRepositoryInfosByOwnerAsync(string owner);
    }

    public class GitHubService : IGitHubService
    {
        private readonly HttpClient _httpClient;

        public GitHubService(IHttpClientFactory httpClientFactory)
        {
            // DO NOT MODIFY
            _httpClient = httpClientFactory.CreateClient(HttpClientNames.GitHubClient);
        }

        public async Task<IEnumerable<RepositoryInfo>> GetRepositoryInfosByOwnerAsync(string owner)
        {
            var response = await _httpClient.GetAsync($"users/{owner}/repos").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<IEnumerable<RepositoryInfo>>(stringResponse);

            return result;
        }
    }
}
