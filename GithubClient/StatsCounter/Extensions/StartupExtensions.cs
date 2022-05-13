using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using StatsCounter.Services;

namespace StatsCounter.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddGitHubService(
            this IServiceCollection services,
            Uri baseApiUrl)
        {
            services.AddHttpClient<GitHubService>(cfg =>
            {
                cfg.BaseAddress = baseApiUrl;
                cfg.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                cfg.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("BaseCodeTest", "1.0"));
            });

            return services;
        }
    }
}