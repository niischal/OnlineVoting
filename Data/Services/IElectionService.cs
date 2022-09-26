using OnlineVoting.Data.Base;
using OnlineVoting.Models;

namespace OnlineVoting.Data.Services
{
    public interface IElectionService : IEntityBaseRepository<Election>
    {
        List<int?> GetByUserIdAsync(string userId);
        List<Election> GetElectionsByElectionId(List<int?> electionIds);
        Task AddUserElection(int electionId, string userId);
    }
}
