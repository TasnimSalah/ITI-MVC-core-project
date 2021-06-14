using Lec1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lec1.Services
{
    public interface IDepartmentCourses
    {
        List<Course> GetDeptCourse(int ? id);

        DepartmentCourses AddCourse(int crsid, int deptid);
        DepartmentCourses RemoveCourse(int crsid, int deptid);
    }

}
