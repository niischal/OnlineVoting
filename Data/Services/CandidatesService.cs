using Microsoft.EntityFrameworkCore;
using OnlineVoting.Data.Base;
using OnlineVoting.Models;

namespace OnlineVoting.Data.Services
{
    public class CandidatesService : EntityBaseRepository<Candidate>, ICandidatesService
    {
        private readonly AppDbContext _context;
        public CandidatesService(AppDbContext context) : base(context)
        {             
            _context=context;
        }

        public async Task<IEnumerable<Candidate>> GetCandidatesAsync(int cId)
        {
            var results = await _context.Candidates.Where(p => p.PositionId == cId).ToListAsync();

            return results;
        }

        public async Task<Candidate> UpdateCandidate(int id, Candidate candidate)
        {
            Candidate c = await _context.Candidates.FindAsync(id);
            c.CandidateIcon = candidate.CandidateIcon;
            c.CandidateName = candidate.CandidateName;
            _context.Attach(c);
            _context.Entry(c).State = EntityState.Modified;
            _context.SaveChanges();
            return c;
        }
    }
}
