using Microsoft.AspNetCore.Mvc;
using Orion_API.Models;
using Orion_API.Services.Interfaces;
using Orion_API.Services;

namespace Orion_API.Controllers.v2
{
    [ApiController]
    [Route("api/v2/[controller]")]
    public class LeadersController : ControllerBase
    {
        private readonly ILeaderService _leaderService;

        public LeadersController(ILeaderService leaderService)
        {
            _leaderService = leaderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var leaders = await _leaderService.GetAllLeadersAsync();
            return Ok(leaders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var leader = await _leaderService.GetLeaderByIdAsync(id);
            if (leader == null)
                return NotFound();

            return Ok(leader);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Leader leader)
        {
            var createdLeader = await _leaderService.CreateLeaderAsync(leader);
            return CreatedAtAction(nameof(GetById), new { id = createdLeader.Id }, createdLeader);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Leader leader)
        {
            await _leaderService.UpdateLeaderAsync(id, leader);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _leaderService.DeleteLeaderAsync(id);
            return NoContent();
        }
    }
}
