using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Wedding.Models;

namespace Wedding.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Attendee attendee)
        {
            if (ModelState.IsValid)
            {
                _context.Attendee.Add(attendee);
                _context.SaveChanges();

                if (attendee.IsAttending == true)
                {
                    var message = "<strong>" + attendee.FirstName + "</strong>" + " - Thank you for your reservation. " + "<br />" + "We look forward to seeing you!";
                    return RedirectToAction("ThankYou", "Home", new { attending = message });
                }
                else if (attendee.IsAttending == false)
                {
                    var sorry = "<strong>" + attendee.FirstName + "</strong>" + " - We're sad that you won't be joining us in celebrating our special day. " + "<br />" + "<br />" + "If anything changes, please contact us!";
                    return RedirectToAction("Sorry", "Home", new { notAttending = sorry });
                }


                return RedirectToAction("Index");
            }
            return View(attendee);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult ThankYou(string attending)
        {
            ViewBag.message = attending;
            return View();
        }

        public IActionResult Sorry(string notAttending)
        {
            ViewBag.sorry = notAttending;
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
