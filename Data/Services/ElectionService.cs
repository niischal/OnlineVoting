using OnlineVoting.Data.Base;
using OnlineVoting.Models;

namespace OnlineVoting.Data.Services
{
    public class ElectionService : EntityBaseRepository<Election>, IElectionService
    {
        public ElectionService(AppDbContext context) : base(context)
        {
        }
    }
}
