using Microsoft.AspNetCore.Mvc;
using Orion_API.Models;
using Orion_API.Services.Interfaces;
using Orion_API.Services;


namespace Orion_API.Controllers.v1
{
    [ApiController]
    [Route("api/v1/leaders")]
    [ApiVersion("1.0")]
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
            return leader == null ? NotFound() : Ok(leader);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Leader leader)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _leaderService.CreateLeaderAsync(leader);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
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
