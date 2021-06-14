using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lec1.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<StudentCourses> Students { get; set; }
        public List<DepartmentCourses> Departments { get; set; }
    }
}
