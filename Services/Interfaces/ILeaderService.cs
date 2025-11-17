using Orion_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orion_API.Services.Interfaces
{
    public interface ILeaderService
    {
        Task<IEnumerable<Leader>> GetAllLeadersAsync();
        Task<Leader?> GetLeaderByIdAsync(int id);
        Task<Leader> CreateLeaderAsync(Leader leader);
        Task UpdateLeaderAsync(int id, Leader updatedLeader);
        Task DeleteLeaderAsync(int id);
    }
}
