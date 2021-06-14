using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lec1.Models;
using Lec1.Services;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Lec1.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudent _context;
        private readonly ITIModel _db;
        private readonly IHostingEnvironment _hostenviroment;

        public StudentsController(IStudent context , ITIModel db , IHostingEnvironment hostenviroment)
        {
            _context = context;
            _db = db;
            _hostenviroment = hostenviroment;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(_context.GetAll());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _context.GetDetails(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["DeptId"] = new SelectList(_db.Departments, "Id", "Name");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentCreateViewModel student)
        {
            if (ModelState.IsValid)
            {
                string UniqueFileName = null;
                string photoName = null;
                if (student.Photo != null)
                {
                    string folder = Path.Combine(_hostenviroment.WebRootPath, "images");
                    photoName = Guid.NewGuid().ToString() + "_" + student.Photo.FileName;
                    string photoPath = Path.Combine(folder, photoName);
                    student.Photo.CopyTo(new FileStream(photoPath, FileMode.Create));
                }
                Student NewStudent = new Student() { Name = student.Name, Age = student.Age, Photo = photoName, DeptId = student.DeptId };
                _context.Add(NewStudent);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeptId"] = new SelectList(_db.Departments, "Id", "Name", student.DeptId);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _context.GetDetails(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["DeptId"] = new SelectList(_db.Departments, "Id", "Name", student.DeptId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,DeptId")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Edit(student);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            ViewData["DeptId"] = new SelectList(_db.Departments, "Id", "Name", student.DeptId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student =  _context.GetDetails(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            _context.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.GetDetails(id)!= null;
        }
    }
}
