using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoursesAppMVC.Data;
using CoursesAppMVC.Models;


namespace CoursesAppMVC.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Courses
        public IActionResult Index()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }

        // GET: Courses/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseItem = _context.Courses.FirstOrDefault(m => m.Id == id);

            if (courseItem == null)
            {
                return NotFound();
            }

            return View(courseItem);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Description,StartDate,EndDate")] CourseItem courseItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseItem);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(courseItem);
        }

        // GET: Courses/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseItem = _context.Courses.FirstOrDefault(m => m.Id == id);

            if (courseItem == null)
            {
                return NotFound();
            }
            return View(courseItem);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Description,StartDate,EndDate")] CourseItem courseItem)
        {
            if (id != courseItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseItem);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseItemExists(courseItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(courseItem);
        }

        // GET: Courses/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseItem = _context.Courses.FirstOrDefault(m => m.Id == id);

            if (courseItem == null)
            {
                return NotFound();
            }

            return View(courseItem);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var courseItem = _context.Courses.Find(id);
            _context.Courses.Remove(courseItem);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseItemExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}
