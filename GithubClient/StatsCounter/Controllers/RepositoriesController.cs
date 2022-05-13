using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StatsCounter.Models;
using StatsCounter.Services;

namespace StatsCounter.Controllers
{
    [Route("repositories")]
    [ApiController]
    public class RepositoriesController : ControllerBase
    {
        private readonly IStatsService _statsService;

        public RepositoriesController(IStatsService statsService)
        {
            _statsService = statsService;
        }

        [HttpGet("{owner}")]
        [ProducesResponseType(typeof(RepositoryStats), StatusCodes.Status200OK)]
        public async Task<ActionResult<RepositoryStats>> Get(
            [FromRoute] string owner)
        {
            var result = await _statsService.GetRepositoryStatsByOwnerAsync(owner).ConfigureAwait(false);
            
            return Ok(result);
        }
    }
}