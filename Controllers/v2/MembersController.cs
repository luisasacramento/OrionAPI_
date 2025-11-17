using Microsoft.AspNetCore.Mvc;
using Orion_API.Models;
using Orion_API.Services.Interfaces;

namespace Orion_API.Controllers.v2
{
    [ApiController]
    [Route("api/v2/members")]
    [ApiVersion("2.0")]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Member member)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _memberService.CreateMemberAsync(member);
            return CreatedAtAction(nameof(Create), new { id = created.Id }, created);
        }

        [HttpGet("by-team/{teamId}")]
        public async Task<IActionResult> GetMembersByTeam(int teamId)
        {
            var members = await _memberService.GetMembersByTeamIdAsync(teamId);
            return Ok(members);
        }
    }
}
