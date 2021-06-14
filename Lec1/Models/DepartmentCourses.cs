using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lec1.Models
{
    public class DepartmentCourses
    {

        [ForeignKey("Departments")]
        public int DeptId { get; set; }


        [ForeignKey("Courses")]

        public int CrsId { get; set; }


        public  Department Departments { get; set; }
        public  Course Courses { get; set; }
    }
}
