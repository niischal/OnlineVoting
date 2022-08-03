using OnlineVoting.Data.Base;
using OnlineVoting.Models;

namespace OnlineVoting.Data.Services
{
    public class PositionService : EntityBaseRepository<Position>, IPositionService
    {
        public PositionService(AppDbContext context) : base(context)
        {
        }
    }
}
