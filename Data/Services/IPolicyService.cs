using OnlineVoting.Data.Base;
using OnlineVoting.Models;

namespace OnlineVoting.Data.Services
{
    public interface IPolicyService : IEntityBaseRepository<Policy>
    {
        Task<IEnumerable<Policy>> GetPolicyAsync(int eId);
        string GetName(int eId);


        Task<Policy> UpdatePolicy(int eId, Policy position);
    }
}
