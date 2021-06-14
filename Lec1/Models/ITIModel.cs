using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lec1.Models
{
    public class ITIModel : DbContext
    {
        public ITIModel(DbContextOptions options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }
        public DbSet<DepartmentCourses> DepartmentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourses>().HasKey(sc => new { sc.StdId, sc.CrstId });
            modelBuilder.Entity<DepartmentCourses>().HasKey(sc => new { sc.DeptId, sc.CrsId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;database=ITIMvc;trusted_connection=true");
        }
    }
}
