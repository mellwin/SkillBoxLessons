using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class PhoneContactController : Controller
    {
        private readonly IRepository repo = new PhoneContactsDBRepo();

        public IActionResult Index()
        {
            var select = repo.SelectAll().Result;
            return View(select);
        }

        public IActionResult Details(Guid input)
        {
            //Guid input = Guid.Parse("3b20ee5b-a9d7-4fbf-9136-021727148020");
            var select = repo.Find(input).Result;
            return View(select);
        }
    }
}