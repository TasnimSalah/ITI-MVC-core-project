using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lec1.Models;

namespace Lec1.Controllers
{
    public class StudentCoursesController : Controller
    {
        private readonly ITIModel db;

        public StudentCoursesController(ITIModel context)
        {
            db = context;
        }

        // GET: StudentCourses
        public async Task<IActionResult> Index(int id)
        {
            var studentCourse = db.StudentCourses.Where(s => s.StdId == id).Include(s => s.Courses).Include(s => s.students);
            var student = db.Students.FirstOrDefault(d => d.Id == id);
            ViewBag.std = student;
            return View(studentCourse.ToList());
        }

        // GET: StudentCourses/Create
        public IActionResult AddCourseGrade(int id)
        {
            var student = db.Students.FirstOrDefault(d => d.Id == id);
            var DeptCourses = db.DepartmentCourses.Where(d => d.DeptId == student.DeptId).Select(c => c.Courses);
            var studentCours = db.StudentCourses.Where(s => s.StdId == id).Select(c => c.Courses);
            //var NewstudentCourse = DeptCourses.Except(studentCours).ToList();

            SelectList NewstudentCourse = new SelectList(DeptCourses.Except(studentCours).ToList(), "Id", "Name");

            ViewBag.std = student;
            ViewBag.NewstudentCourse = NewstudentCourse;
            //ViewBag.DeptCourse = DeptCourses.ToList();
            return View();
        }

        // POST: StudentCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCourseGrade(StudentCourses stdcrs)
        {
            if (ModelState.IsValid == true)
            {
                db.StudentCourses.Add(new StudentCourses() { StdId = stdcrs.StdId, CrstId = stdcrs.CrstId, Grade = stdcrs.Grade });
            }



            db.SaveChanges();
            return RedirectToAction("Index", new { id = stdcrs.StdId });
        }

        // GET: StudentCourses/Edit/5
        public async Task<IActionResult> Edit(int? StdId, int? CrstId)
        {
            if (StdId == null || CrstId ==null)
            {
                return BadRequest();
            }
            StudentCourses studentCourse = db.StudentCourses.FirstOrDefault(sc => sc.CrstId == CrstId && sc.StdId == StdId);
            if (studentCourse == null)
            {
                return NotFound();
            }

            ViewBag.student = db.Students.FirstOrDefault(d => d.Id == StdId);
            ViewBag.course = db.Courses.FirstOrDefault(d => d.Id == CrstId);

            return View(studentCourse);
        }

        // POST: StudentCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentCourses studentCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = studentCourse.StdId });
            }
            ViewBag.CrstId = new SelectList(db.Courses, "Id", "Name", studentCourse.CrstId);
            ViewBag.StdId = new SelectList(db.Students, "Id", "Name", studentCourse.StdId);
            return View(studentCourse);
        }

        // GET: StudentCourses/Delete/5
        public async Task<IActionResult> Delete(int ? StdId, int ? CrstId)
        {
            if (StdId == null || CrstId == null)
            {
                return BadRequest();
            }
            StudentCourses studentCourse = db.StudentCourses.FirstOrDefault(sc => sc.CrstId == CrstId && sc.StdId == StdId);
            if (studentCourse == null)
            {
                return NotFound();
            }
            ViewBag.student = db.Students.FirstOrDefault(d => d.Id == StdId);
            return View(studentCourse);
        }
        // POST: StudentCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int StdId, int CrstId)
        {
            StudentCourses studentCourse = db.StudentCourses.FirstOrDefault(sc => sc.CrstId == CrstId && sc.StdId == StdId);
            db.StudentCourses.Remove(studentCourse);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = studentCourse.StdId });
        }

        private bool StudentCoursesExists(int id)
        {
            return db.StudentCourses.Any(e => e.StdId == id);
        }
    }
}
