using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineVoting.Data;
using OnlineVoting.Data.Services;
using OnlineVoting.Data.Static;
using OnlineVoting.Models;

namespace OnlineVoting.Controllers
{
    
    public class CandidateController : Controller
    {
        private readonly ICandidatesService _service;
        public CandidateController(ICandidatesService service)
        {
            _service = service;
        }
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Index(int id)
        {
            var candidate=await _service.GetCandidatesAsync(id);
            ViewBag.PId = id;
            return View(candidate);
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.Id = id;    
            return View();
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("CandidateIcon,CandidateName,PositionId")]Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                return View(candidate);
            }
            await _service.AddAsync(candidate);
            return Redirect("../Index/"+candidate.PositionId);
        }
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Update(int id)
        {
            var candidate = await _service.GetByIdAsync(id);
            if (candidate == null) return View("NotFound");
            return View(candidate);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> Update(int id, [Bind("CandidateIcon,CandidateName,PositionId")] Candidate candidate)
        {

            if (ModelState.IsValid)
            {
                return View(candidate);
            }

            ViewBag.EId = candidate.PositionId;
            await _service.UpdateCandidate(id, candidate);

            return Redirect("../Index/" + id);
        }
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Remove(int id)
        {
            var Candidate = await _service.GetByIdAsync(id);
            if (Candidate == null) return View("NotFound");
            return View(Candidate);
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost, ActionName("Remove")]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            var candidate = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(id);

            return Redirect("../Index/" + candidate.PositionId);
            //return RedirectToAction("Index");
        }
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var candidate = await _service.GetByIdAsync(id);
            if (candidate == null) return View("NotFound");
            return View(candidate);
        }


    }
}
