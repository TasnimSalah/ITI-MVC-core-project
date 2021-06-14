using Lec1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lec1.Services
{
    public class StudentDB : IStudent
    {
        private ITIModel _itidb;

        public StudentDB(ITIModel itidb)
        {
            this._itidb = itidb;
        }

        Student IStudent.Add(Student std)
        {
            _itidb.Add(std);
            _itidb.SaveChanges();
            return std;
        }

        Student IStudent.Delete(int id)
        {
            Student std = _itidb.Students.FirstOrDefault(s => s.Id == id);
            _itidb.Remove(std);
            _itidb.SaveChanges();
            return std;
        }

        Student IStudent.Edit(Student std)
        {
            Student selected = _itidb.Students.FirstOrDefault(s => s.Id == std.Id);
            selected.Name = std.Name;
            selected.Age = std.Age;
            selected.DeptId = std.DeptId;
            _itidb.SaveChanges();
            return selected;
        }

        List<Student> IStudent.GetAll()
        {
            return _itidb.Students.Include(s => s.Department).ToList();
           
        }

        Student IStudent.GetDetails(int? id)
        {
            Student std = _itidb.Students.Include(s => s.Department).FirstOrDefault(m => m.Id == id);
            return std;
           
        }
    }
}
