using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            var select = _repo.SelectAll().Result;
            return View(select);
        }

        public IActionResult Details(Guid id)
        {
            var select = _repo.Find(id).Result;
            return View(select);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // GET:
        [HttpGet]
        public IActionResult FindContact(Guid input)
        {
            var select =  _repo.Find(input).Result;
            //return View(select);
            return Redirect($"~/PhoneContact/Details/{input}");
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Add(PhoneContact input)
        {
            await _repo.Insert(input);
            return Redirect("~/");
        }

        // PUT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id, Name, Phonenumber, Address, Descriptions")]PhoneContact input)
        {
            await _repo.Update(input);
            return Redirect("~/");
        }

        // DELETE
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repo.Delete(id); 
            return RedirectToAction("Index");
        }
    }
}