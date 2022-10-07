using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineVoting.Data;
using OnlineVoting.Data.Static;
using OnlineVoting.Models;

namespace OnlineVoting.Controllers
{
    [Authorize(Roles = UserRoles.Voter)]
    public class VotingBoothController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;
        public VotingBoothController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private async Task<Voter?> GetVoter(int eId)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            var voter = _context.Voters.Where(x => x.UserId == user.Id && x.ElectionId== eId).FirstOrDefault();
            return voter;
        }
        public async Task<IActionResult> Index(int Id)
        {
            Election? election = _context.Elections.Find(Id);
            ViewBag.Election=election;

            List<Position> positions = new List<Position>();
            positions = _context.Positions.Where(p => p.ElectionId == Id).ToList();
            positions.ForEach(position =>
            {
                position.Candidates = _context.Candidates.Where(p=> p.PositionId == position.Id).ToList();

            } );
            ViewBag.Positions = positions;
            var voter = await GetVoter(Id);
            ViewBag.canVote = voter.canVote;

            return View();
        }

        public IActionResult Result(int Id)
        {
            Election? election = _context.Elections.Find(Id);
            ViewBag.Election = election;

            List<Position> positions = new List<Position>();
            positions = _context.Positions.Where(p => p.ElectionId == Id).ToList();
            positions.ForEach(position =>
            {
                position.Candidates = _context.Candidates.Where(p => p.PositionId == position.Id).ToList();

            });
            ViewBag.Positions = positions;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddVote(VotedCandidate vc)
        {
            if (vc != null)
            {
                foreach (var item in vc.VotedCandidates)
                {
                    Candidate? c = _context.Candidates.Find(item);
                    c.CandidateVoteCount++;
                    _context.Attach(c);
                    _context.Entry(c).State = EntityState.Modified;
                    _context.SaveChanges();

                }
                var voter =  await GetVoter(vc.eId);
                voter.canVote = false;
                _context.Update(voter);
                _context.SaveChanges();
            }
            
            return RedirectToAction("Index","Election");
        }


        public async Task<IActionResult> PolicyIndexAsync(int Id)
        {
            Election? election = _context.Elections.Find(Id);

            List<Policy> policies = new List<Policy>();
            policies = _context.Policies.Where(p => p.ElectionId == Id).ToList();
            //policies.ForEach(position =>
            //{
            //    position.Candidates = _context.Candidates.Where(p => p.PositionId == position.Id).ToList();

            //});

            ViewBag.Election = election;
            ViewBag.Policies = policies;

            var voter = await GetVoter(Id);
            ViewBag.canVote = voter.canVote;

            return View();
        }

        public IActionResult PolicyResult(int Id)
        {
            Election? election = _context.Elections.Find(Id);
            ViewBag.Election = election;

            List<Policy> policies = new List<Policy>();
            policies = _context.Policies.Where(p => p.ElectionId == Id).ToList();
            return View(policies);
        }

        [HttpPost]
        public async Task<IActionResult> PolicyAddVoteAsync(List<PolicyVote> policyVotes)
        {
            if (policyVotes != null)
            {
                
                foreach (var policyVote in policyVotes)
                {
                    Policy? p = _context.Policies.Find(policyVote.Id);

                    if (policyVote.Vote == "Yes")
                    {
                        p.PolicyYesVote++;
                    }
                    else
                    {
                        p.PolicyNoVote++;
                    }
                    _context.Attach(p);
                    _context.Entry(p).State = EntityState.Modified;
                    _context.SaveChanges();

                    
                }
                var eId = policyVotes.Select(x => x.eId).FirstOrDefault();
                var voter = await GetVoter(eId);
                voter.canVote = false;
                _context.Update(voter);
                _context.SaveChanges();
            }
            
            
            return RedirectToAction("Index", "Election");
        }
    }
}
