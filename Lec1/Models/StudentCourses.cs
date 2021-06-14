using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lec1.Models
{
    public class StudentCourses
    {

        [ForeignKey("students")]
        public int StdId { get; set; }


        [ForeignKey("Courses")]
        public int CrstId { get; set; }
        public int? Grade { get; set; }

        public virtual Student students { get; set; }
        public virtual Course Courses { get; set; }
    }
}
