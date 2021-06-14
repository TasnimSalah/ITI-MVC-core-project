using Lec1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lec1.Services
{
    public class CourseDB:ICourse
    {
        private ITIModel _itidb;

        public CourseDB(ITIModel itidb)
        {
            this._itidb = itidb;
        }

        Course ICourse.Add(Course crs)
        {
            _itidb.Add(crs);
            _itidb.SaveChanges();
            return crs;
        }

        Course ICourse.Delete(int id)
        {
            Course crs = _itidb.Courses.FirstOrDefault(s => s.Id == id);
            _itidb.Remove(crs);
            _itidb.SaveChanges();
            return crs;
        }

        Course ICourse.Edit(Course crs)
        {
            Course selected = _itidb.Courses.FirstOrDefault(s => s.Id == crs.Id);
            selected.Name = crs.Name;
            _itidb.SaveChanges();
            return selected;
        }

        List<Course> ICourse.GetAll()
        {
            return _itidb.Courses.ToList();

        }

        Course ICourse.GetDetails(int? id)
        {
            Course crs = _itidb.Courses.FirstOrDefault(m => m.Id == id);
            return crs;

        }
    }
}
