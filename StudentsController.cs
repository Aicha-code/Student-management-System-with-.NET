using Microsoft.AspNetCore.Mvc;
using StudentApp.Data;
using StudentApp.Models;

namespace StudentApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentDbContext _context;

        public StudentsController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }





        // GET: Students/Edit/5
public IActionResult Edit(int id)
{
    var student = _context.Students.Find(id);
    if (student == null)
    {
        return NotFound();
    }
    return View(student);
}

// POST: Students/Edit/5
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Edit(int id, Student student)
{
    if (id != student.Id)
    {
        return BadRequest();
    }

    if (ModelState.IsValid)
    {
        _context.Update(student);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    return View(student);
}


        // POST: Students/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
