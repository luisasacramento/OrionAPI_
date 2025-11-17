using Microsoft.EntityFrameworkCore;
using Orion_API.Data;
using Orion_API.Models;
using Orion_API.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orion_API.Services
{
    public class LeaderService : ILeaderService
    {
        private readonly OrionContext _context;

        public LeaderService(OrionContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Leader>> GetAllLeadersAsync()
        {
            return await _context.Leaders
                .Include(l => l.Teams)
                .ThenInclude(t => t.Members)
                .ToListAsync();
        }

        public async Task<Leader?> GetLeaderByIdAsync(int id)
        {
            return await _context.Leaders
                .Include(l => l.Teams)
                .ThenInclude(t => t.Members)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Leader> CreateLeaderAsync(Leader leader)
        {
            _context.Leaders.Add(leader);
            await _context.SaveChangesAsync();
            return leader;
        }

        public async Task UpdateLeaderAsync(int id, Leader updatedLeader)
        {
            var existingLeader = await _context.Leaders.FindAsync(id);
            if (existingLeader != null)
            {
                existingLeader.Name = updatedLeader.Name;
                existingLeader.Role = updatedLeader.Role;
                existingLeader.Teams = updatedLeader.Teams;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteLeaderAsync(int id)
        {
            var leader = await _context.Leaders.FindAsync(id);
            if (leader != null)
            {
                _context.Leaders.Remove(leader);
                await _context.SaveChangesAsync();
            }
        }
    }
}
