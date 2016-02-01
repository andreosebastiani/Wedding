using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Wedding.Models;

namespace Wedding.Controllers
{
    public class AttendeesController : Controller
    {
        private ApplicationDbContext _context;

        public AttendeesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Attendees
        public IActionResult Index()
        {
            return View(_context.Attendee.ToList());
        }

        // GET: Attendees/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Attendee attendee = _context.Attendee.Single(m => m.AttendeeID == id);
            if (attendee == null)
            {
                return HttpNotFound();
            }

            return View(attendee);
        }

        // GET: Attendees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attendees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Attendee attendee)
        {
            if (ModelState.IsValid)
            {
                _context.Attendee.Add(attendee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attendee);
        }

        // GET: Attendees/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Attendee attendee = _context.Attendee.Single(m => m.AttendeeID == id);
            if (attendee == null)
            {
                return HttpNotFound();
            }
            return View(attendee);
        }

        // POST: Attendees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Attendee attendee)
        {
            if (ModelState.IsValid)
            {
                _context.Update(attendee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attendee);
        }

        // GET: Attendees/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Attendee attendee = _context.Attendee.Single(m => m.AttendeeID == id);
            if (attendee == null)
            {
                return HttpNotFound();
            }

            return View(attendee);
        }

        // POST: Attendees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Attendee attendee = _context.Attendee.Single(m => m.AttendeeID == id);
            _context.Attendee.Remove(attendee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
