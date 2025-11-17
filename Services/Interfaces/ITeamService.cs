using Orion_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orion_API.Services.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllTeamsAsync();
        Task<Team?> GetTeamByIdAsync(int id);
        Task<Team> CreateTeamAsync(Team team);
    }
}
