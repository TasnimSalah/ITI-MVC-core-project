using Lec1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lec1.Services
{
    public class DepartmentDB : IDepartment
    {
        private ITIModel _itidb;

        public DepartmentDB(ITIModel itidb)
        {
            _itidb = itidb;
        }

        Department IDepartment.Add(Department dept)
        {
            _itidb.Departments.Add(dept);
            _itidb.SaveChanges();
            return dept;
        }

        Department IDepartment.Delete(int id)
        {
           Department dept = _itidb.Departments.FirstOrDefault(d => d.Id == id);
            _itidb.Departments.Remove(dept);
            _itidb.SaveChanges();
            return dept;
        }

        Department IDepartment.Edit(Department dept)
        {
            Department selectedDept = _itidb.Departments.FirstOrDefault(d => d.Id == dept.Id);
            selectedDept.Name = dept.Name;
            _itidb.SaveChanges();
            return selectedDept;
        }

        List<Department> IDepartment.GetAll()
        {
            return _itidb.Departments.ToList();
        }

        Department IDepartment.GetDetails(int? id)
        {
            return _itidb.Departments.FirstOrDefault(d=>d.Id == id);
            
        }

    }
}
