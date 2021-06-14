using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lec1.Models
{
    public class StudentCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }

        [ForeignKey("Department")]
        public int? DeptId { get; set; }

        public IFormFile ? Photo { get; set; }

        public Department Department { get; set; }
    }
}
