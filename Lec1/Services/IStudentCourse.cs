using Lec1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lec1.Services
{
    public interface IStudentCourse
    {
        List<StudentCourses> GetAllStudentGrdes(int id);

        StudentCourses AddGrade(int id, int crsid, int grade);

        StudentCourses Edit(StudentCourses stdcrs);
        StudentCourses Delete(StudentCourses stdcrs);
    }

    public class StudentCourseDB : IStudentCourse
    {
        private readonly ITIModel _itidb;
        public StudentCourseDB(ITIModel itidb)
        {
            _itidb = itidb;

        }
        StudentCourses IStudentCourse.AddGrade(int id, int crsid, int grade)
        {
            StudentCourses stdcrs = new StudentCourses() { CrstId = crsid, StdId = id, Grade = grade };
            _itidb.StudentCourses.Add(stdcrs);
            _itidb.SaveChanges();
            return stdcrs;

        }

        StudentCourses IStudentCourse.Delete(StudentCourses stdcrs)
        {
            throw new NotImplementedException();
        }

        StudentCourses IStudentCourse.Edit(StudentCourses stdcrs)
        {
            throw new NotImplementedException();
        }

        List<StudentCourses> IStudentCourse.GetAllStudentGrdes(int id)
        {
            throw new NotImplementedException();
        }
    }
}
