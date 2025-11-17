using Microsoft.AspNetCore.Mvc;
using Orion_API.Models;
using Orion_API.Services.Interfaces;

namespace Orion_API.Controllers.v1
{
    [ApiController]
    [Route("api/v1/teams")]
    [ApiVersion("1.0")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Team team)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _teamService.CreateTeamAsync(team);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var team = await _teamService.GetTeamByIdAsync(id);
            return team == null ? NotFound() : Ok(team);
        }
    }
}
