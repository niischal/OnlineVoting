using OnlineVoting.Data.Base;
using OnlineVoting.Models;

namespace OnlineVoting.Data.Services
{
    public interface ICandidatesService : IEntityBaseRepository<Candidate>
    {
        Task<IEnumerable<Candidate>> GetCandidatesAsync(int cId);
        Task<Candidate> UpdateCandidate(int cId, Candidate candidate);
    }
}
