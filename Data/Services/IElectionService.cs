using OnlineVoting.Data.Base;
using OnlineVoting.Models;

namespace OnlineVoting.Data.Services
{
    public interface IElectionService : IEntityBaseRepository<Election>
    {
    }
}
