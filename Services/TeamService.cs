using Microsoft.EntityFrameworkCore;
using Orion_API.Data;
using Orion_API.Models;
using Orion_API.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orion_API.Services
{
    public class TeamService : ITeamService
    {
        private readonly OrionContext _context;

        public TeamService(OrionContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            return await _context.Teams
                .Include(t => t.Leader)
                .Include(t => t.Members)
                .ToListAsync();
        }

        public async Task<Team?> GetTeamByIdAsync(int id)
        {
            return await _context.Teams
                .Include(t => t.Leader)
                .Include(t => t.Members)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Team> CreateTeamAsync(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return team;
        }
    }
}
