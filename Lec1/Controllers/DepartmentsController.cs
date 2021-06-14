using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lec1.Models;
using Lec1.Services;

namespace Lec1.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartment _context;

        private readonly ICourse _crsdb;

        private readonly IDepartmentCourses _deptcrs;

        public DepartmentsController(IDepartment context , ICourse crsdb , IDepartmentCourses deptcrs)
        {
            _context = context;
            _crsdb = crsdb;
            _deptcrs = deptcrs;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            return View(_context.GetAll());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department =  _context.GetDetails(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department =  _context.GetDetails(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Edit(department);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.Id))
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
            return View(department);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department =  _context.GetDetails(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = _context.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
            return _context.GetDetails(id)!= null;
        }


        public async Task<IActionResult> AddCourse(int id )
        {
            var AllCourses = _crsdb.GetAll();
            var DeptCourses = _deptcrs.GetDeptCourse(id);
            var NewCourses = AllCourses.Except(DeptCourses).ToList();

            ViewBag.Dept = _context.GetDetails(id);
            return View(NewCourses);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(int id, Dictionary<string, bool> crs)
        {
            foreach (KeyValuePair<string, bool> item in crs)
            {
                if (item.Value == true)
                {
                    _deptcrs.AddCourse(int.Parse(item.Key), id);
                }
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> RemoveCourse(int id)
        {
            var DeptCourses = _deptcrs.GetDeptCourse(id);

            ViewBag.Dept = _context.GetDetails(id);
            return View(DeptCourses);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCourse(int id, Dictionary<string, bool> crs)
        {
            foreach (KeyValuePair<string, bool> item in crs)
            {
                if (item.Value == true)
                {
                    int crid = int.Parse(item.Key);
                    _deptcrs.RemoveCourse(crid, id);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
