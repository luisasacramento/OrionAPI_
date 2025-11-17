using Microsoft.AspNetCore.Mvc;
using Orion_API.Models;
using Orion_API.Services.Interfaces;

namespace Orion_API.Controllers.v1
{
    [ApiController]
    [Route("api/v1/members")]
    [ApiVersion("1.0")]
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
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var member = await _memberService.GetMemberByIdAsync(id);
            return member == null ? NotFound() : Ok(member);
        }
    }
}
