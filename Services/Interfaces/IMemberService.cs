using Orion_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orion_API.Services.Interfaces
{
    public interface IMemberService
    {
        Task<Member?> GetMemberByIdAsync(int id);
        Task<IEnumerable<Member>> GetMembersByTeamIdAsync(int teamId);
        Task<Member> CreateMemberAsync(Member member);
    }
}
