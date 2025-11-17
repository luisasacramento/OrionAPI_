using Microsoft.EntityFrameworkCore;
using Orion_API.Data;
using Orion_API.Models;
using Orion_API.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orion_API.Services
{
    public class MemberService : IMemberService
    {
        private readonly OrionContext _context;

        public MemberService(OrionContext context)
        {
            _context = context;
        }

        public async Task<Member?> GetMemberByIdAsync(int id)
        {
            return await _context.Members
                .Include(m => m.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Member>> GetMembersByTeamIdAsync(int teamId)
        {
            return await _context.Members
                .Where(m => m.TeamId == teamId)
                .Include(m => m.Team)
                .ToListAsync();
        }

        public async Task<Member> CreateMemberAsync(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return member;
        }
    }
}
