using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineVoting.Data;
using OnlineVoting.Models;

namespace OnlineVoting.Controllers
{
    public class VotingBoothController : Controller
    {
        private readonly AppDbContext _context;
        public VotingBoothController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int Id)
        {
            Election election = _context.Elections.Find(Id);
            ViewBag.Election=election;

            List<Position> positions = new List<Position>();
            positions = _context.Positions.Where(p => p.ElectionId == Id).ToList();
            positions.ForEach(position =>
            {
                position.Candidates = _context.Candidates.Where(p=> p.PositionId == position.Id).ToList();

            } );
            ViewBag.Positions = positions;
            return View();
        }

        public IActionResult Result(int Id)
        {
            Election election = _context.Elections.Find(Id);
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
        public IActionResult AddVote(VotedCandidate vc)
        {


            foreach (var item in vc.VotedCandidates)
            {
                Candidate c = _context.Candidates.Find(item);
                c.CandidateVoteCount++;
                _context.Attach(c);
                _context.Entry(c).State = EntityState.Modified;
                _context.SaveChanges();

            }
            return RedirectToAction("Index","Election");
        }


        public IActionResult PolicyIndex(int Id)
        {
            Election election = _context.Elections.Find(Id);

            List<Policy> policies = new List<Policy>();
            policies = _context.Policies.Where(p => p.ElectionId == Id).ToList();
            //policies.ForEach(position =>
            //{
            //    position.Candidates = _context.Candidates.Where(p => p.PositionId == position.Id).ToList();

            //});

            ViewBag.Election = election;
            ViewBag.Policies = policies;
            return View();
        }

        public IActionResult PolicyResult(int Id)
        {
            Election election = _context.Elections.Find(Id);
            ViewBag.Election = election;

            List<Policy> policies = new List<Policy>();
            policies = _context.Policies.Where(p => p.ElectionId == Id).ToList();
            return View(policies);
        }

        [HttpPost]
        public IActionResult PolicyAddVote(List<PolicyVote> policyVotes)
        {
            foreach (var policyVote in policyVotes)
            {
                Policy p = _context.Policies.Find(policyVote.Id);
               
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
            return RedirectToAction("Index", "Election");
        }
    }
}
