using OnlineVoting.Data.Base;
using OnlineVoting.Models;

namespace OnlineVoting.Data.Services
{
    public interface IPositionService : IEntityBaseRepository<Position>
    {
        Task<IEnumerable<Position>> GetPositionAsync(int eId);
        string GetName(int eId);


        Task<Position> UpdatePosition(int eId, Position position);

    }
    
}
