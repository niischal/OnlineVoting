

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineVoting.Data;
using OnlineVoting.Data.Services;
using OnlineVoting.Data.Static;
using OnlineVoting.Models;

namespace OnlineVoting.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class PolicyController : Controller
    {
        private readonly IPolicyService _service;
        public PolicyController(IPolicyService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(int id)
        {
            var policies = await _service.GetPolicyAsync(id);
            ViewBag.ElectionId = id;
            return View(policies);
        }
        public IActionResult Create(int id)
        {
            ViewBag.ElectionId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("PolicyTitle,PolicyDescription,ElectionId")] Policy policies)
        {
            if (ModelState.IsValid)
            {
                return View(policies);
            }
            await _service.AddAsync(policies); 
            return Redirect("../Index/" + policies.ElectionId);
        }
        public async Task<IActionResult> Update(int id)
        {
            var policy = await _service.GetByIdAsync(id);
            ViewBag.ElectionId = id;
            if (policy == null) return View("NotFound");
            return View(policy);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, [Bind("PolicyTitle,PolicyDescription,ElectionId")] Policy policy)
        {

            if (ModelState.IsValid)
            {
                return View(policy);
            }

            ViewBag.EId = policy.ElectionId;
            await _service.UpdatePolicy(id, policy);

            return Redirect("../Index/" + policy.ElectionId);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var Position = await _service.GetByIdAsync(id);
            if (Position == null) return View("NotFound");
            return View(Position);
        }
        [HttpPost, ActionName("Remove")]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            var policy = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(id);

            return Redirect("../Index/" + policy.ElectionId);
            //return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            var policy = await _service.GetByIdAsync(id);
            if (policy == null) return View("NotFound");
            return View(policy);
        }
    }
}
