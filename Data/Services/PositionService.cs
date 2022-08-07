using Microsoft.EntityFrameworkCore;
using OnlineVoting.Data.Base;
using OnlineVoting.Models;

namespace OnlineVoting.Data.Services
{
    public class PositionService : EntityBaseRepository<Position>, IPositionService
    {
        private readonly AppDbContext _context;
        public PositionService(AppDbContext context) : base(context)
        {
            _context = context;
        }
        
        //public async Task AddPosAsync(Position p)
        //{
        //    await _context.Positions.AddAsync(p);
        //    await _context.SaveChangesAsync();
        //}

        public  string GetName(int eId)
        {
            var results = _context.Elections.Where(p => p.Id == eId).Select(e=> e.ElectionName).FirstOrDefault();
            return results;
        }

        public async Task<IEnumerable<Position>> GetPositionAsync(int eId)
        {
            var results = await _context.Positions.Where(p=>p.ElectionId == eId).ToListAsync();
            
            return results;
        }
        public async Task<Position> UpdatePosition(int id, Position position)
        {
            Position p = await _context.Positions.FindAsync(id);
            p.PositionTitle = position.PositionTitle;
            p.Description = position.Description;
            _context.Attach(p);
            _context.Entry(p).State = EntityState.Modified;
            _context.SaveChanges();
            return p;
        }
    }
}
