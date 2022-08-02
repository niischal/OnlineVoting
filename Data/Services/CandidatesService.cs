using Microsoft.EntityFrameworkCore;
using OnlineVoting.Data.Base;
using OnlineVoting.Models;

namespace OnlineVoting.Data.Services
{
    public class CandidatesService : EntityBaseRepository<Candidate>, ICandidatesService
    {
        public CandidatesService(AppDbContext context) : base(context) { }
       
       
    }
}
