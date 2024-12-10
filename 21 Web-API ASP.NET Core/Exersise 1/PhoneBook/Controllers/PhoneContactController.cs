using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Data;
using PhoneBook.Models;

namespace PhoneBook.Controllers
{
    public class PhoneContactController : Controller
    {
        private readonly IRepository _repo;

        public PhoneContactController(IRepository repo)
        {
            _repo = repo;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var select = await _repo.SelectAll();
            return View(select);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var select = await _repo.Find(id);
            return View(select);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        // GET:
        [HttpGet]
        public async Task<IActionResult> FindContact(Guid input)
        {
            var select = await _repo.Find(input);
            return Redirect($"~/PhoneContact/Details/{input}");
        }

        // POST
        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Add(PhoneContact input)
        {
            await _repo.Insert(input);
            return Redirect("~/");
        }

        // PUT
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Edit([Bind("Id, Name, PhoneNumber, Address, Descriptions")] PhoneContact input)
        {
            if (User.IsInRole("Admin"))
            {
                await _repo.Update(input);
                return Redirect("~/");
            }
            else
            {
                return Redirect("~/");
            }
        }

        // DELETE
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}