using Microsoft.AspNetCore.Mvc;
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
    }
}
