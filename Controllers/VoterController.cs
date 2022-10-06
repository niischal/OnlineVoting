using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineVoting.Data;
using OnlineVoting.Data.Services;
using OnlineVoting.Data.Static;
using OnlineVoting.Models;

namespace OnlineVoting.Controllers
{
    public class VoterController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        private readonly IElectionService _electionService;
        public VoterController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context, IElectionService electionService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _electionService = electionService;
        }
        [Authorize(Roles = UserRoles.Voter)]
        public IActionResult VoterRegister()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Voter)]
        public IActionResult VoterRegister(VoterRegistration voterDetails)
        {
            if (voterDetails == null) return View(voterDetails);
            List<Voter> voter = _context.Voters.Where(x => x.UniqueId == voterDetails.UniqueId && x.ElectionId == voterDetails.ElectionId).ToList();
            if (voter.Count == 0)
            {
                Voter vr = new Voter();
                vr.ElectionId = voterDetails.ElectionId;
                vr.UniqueId = voterDetails.UniqueId;
                vr.UserId = _userManager.GetUserId(User);
                _context.Voters.Add(vr);
                _context.SaveChanges();
                var voterReg=AddToVoterRegistration(vr);
                vr.ReqId = voterReg.ReqId;
                _context.Voters.Update(vr);
                _context.SaveChanges();
            }

            return RedirectToAction("Success");
        }
        private VoterRegistration AddToVoterRegistration(Voter voter)
        {
            var voterRequests = _context.VoterRegistrations.Where(x => x.UniqueId == voter.UniqueId && x.ElectionId == voter.ElectionId).ToList();
            VoterRegistration vr = new VoterRegistration();
            if (voterRequests.Count == 0)
            {
                vr.ElectionId = (int)voter.ElectionId;
                vr.VoterId = voter.VoterId;
                vr.UniqueId = voter.UniqueId;
                _context.VoterRegistrations.Add(vr);
                _context.SaveChanges();
            }
            return vr;
        }
        public IActionResult Success()
        {
            return View();
        }


        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult VotersToBeVerified()
        {
            var admin = _userManager.GetUserId(User);
            var eids = _context.UserElections.Where(x => x.UserId == admin).Select(x => x.ElectionId).ToList();
            List<VoterRegistration>? vrs = new List<VoterRegistration>();
            foreach (var e in eids)
            {
                var vr = _context.VoterRegistrations.Where(x => x.ElectionId == e).ToList();
                vrs.AddRange(vr);
            }
            return View(vrs);
        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Accept(int id)
        {
            var voterDetails = _context.VoterRegistrations.Where(x => x.ReqId == id).FirstOrDefault();
            var voter = _context.Voters.Where(x => x.ReqId == id).FirstOrDefault();
            var user = _context.Users.Where(x=> x.Id == voter.UserId).FirstOrDefault();
            await _electionService.AddUserElection(voterDetails.ElectionId, user.Id);
            _context.VoterRegistrations.Remove(voterDetails);
            _context.SaveChanges();
            return RedirectToAction("VotersToBeVerified");
        }


        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult Discard(int id)
        {
            var VoterDetails = _context.VoterRegistrations.Where(x => x.ReqId == id).FirstOrDefault();
            _context.VoterRegistrations.Remove(VoterDetails);
            _context.SaveChanges();
            return RedirectToAction("VotersToBeVerified");
        }
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult Details(int id)
        {
            var voterDetails = _context.VoterRegistrations.Where(x => x.ReqId == id).FirstOrDefault();
            ViewBag.Election = _context.Elections.Where(x => x.Id == voterDetails.ElectionId).Select(x => x.ElectionName).FirstOrDefault();


            return View(voterDetails);
        }
    }
}
