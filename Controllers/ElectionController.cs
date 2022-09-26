using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineVoting.Data;
using OnlineVoting.Data.Services;
using OnlineVoting.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using OnlineVoting.Data.Static;

namespace OnlineVoting.Controllers
{
    public class ElectionController : Controller
    {
        private readonly IElectionService _service;
        private readonly UserManager<ApplicationUser> _userManager;
        public ElectionController(IElectionService service, UserManager<ApplicationUser> UserManager)
        {
            _service = service;
            _userManager = UserManager; 
        }



        public IActionResult Index()
        {
            var id = _userManager.GetUserId(User);
            var UserElections = _service.GetByUserIdAsync(id);
            List<Election>? elections = _service.GetElectionsByElectionId(UserElections);
            return View(elections);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> Create(Election election)
        {
            if (ModelState.IsValid)
            {
                return View(election);
            }
            await _service.AddAsync(election);
            var id = _userManager.GetUserId(User);
            await _service.AddUserElection(election.Id,id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Update(int id)
        {
            var election = await _service.GetByIdAsync(id);
            if (election == null) return View("NotFound");
            return View(election);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> Update(int id, Election elections)
        {
            if (ModelState.IsValid)
            {
                return View(elections);
            }
            await _service.UpdateAsync(id,elections);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = UserRoles.Admin)]
        public async Task< IActionResult> Remove(int id)
        {
            var election = await _service.GetByIdAsync(id);
            if (election == null) return View("NotFound");
            return View(election);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost,ActionName("Remove")]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            await _service.RemoveAsync(id);
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var election = await _service.GetByIdAsync(id);
            if (election == null) return View("NotFound");
            return View(election);
        }

     
    }
}
