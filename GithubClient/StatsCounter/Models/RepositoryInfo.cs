using Newtonsoft.Json;

namespace StatsCounter.Models
{
    public class RepositoryInfo
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("stargazers_count")]
        public long StargazersCount { get; set; }
        
        [JsonProperty("watchers_count")]
        public long WatchersCount { get; set; }
        
        [JsonProperty("forks_count")]
        public long ForksCount { get; set; }
        
        [JsonProperty("size")]
        public long Size { get; set; }
    }
}