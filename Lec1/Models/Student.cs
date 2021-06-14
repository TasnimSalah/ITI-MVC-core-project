using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lec1.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int Age { get; set; }

        [ForeignKey("Department")]
        public int? DeptId { get; set; }

        public string ? Photo { get; set; }

        public  Department Department { get; set; }
        public  List<StudentCourses> Courses { get; set; }
    }
}
