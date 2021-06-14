using Lec1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lec1.Services
{
    public class DepartmentCoursesDB : IDepartmentCourses
    {
        private readonly ITIModel _itidb;

        public DepartmentCoursesDB(ITIModel itidb)
        {
            _itidb = itidb;
        }
        public List<Course> GetDeptCourse(int? id)
        {
            return _itidb.DepartmentCourses.Where(d => d.DeptId == id).Select(s => s.Courses).ToList();
        }

        DepartmentCourses IDepartmentCourses.AddCourse(int crsid, int deptid)
        {
            DepartmentCourses deptcrs = new DepartmentCourses() { CrsId = crsid, DeptId = deptid };
            _itidb.DepartmentCourses.Add(deptcrs);
            _itidb.SaveChanges();
            return deptcrs;
        }

        DepartmentCourses IDepartmentCourses.RemoveCourse(int crsid, int deptid)
        {
            DepartmentCourses deptcrs = _itidb.DepartmentCourses.FirstOrDefault(d => d.CrsId == crsid && d.DeptId == deptid);
            _itidb.DepartmentCourses.Remove(deptcrs);
            _itidb.SaveChanges();
            return deptcrs;
        }
    }
}
