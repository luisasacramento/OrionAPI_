using Microsoft.AspNetCore.Mvc;
using Orion_API.Models;
using Orion_API.Services.Interfaces;

namespace Orion_API.Controllers.v2
{
    [ApiController]
    [Route("api/v2/teams")]
    [ApiVersion("2.0")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teams = await _teamService.GetAllTeamsAsync();
            return Ok(teams);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Team team)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _teamService.CreateTeamAsync(team);
            return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
        }
    }
}
