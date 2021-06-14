using Lec1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lec1.Services
{
    public interface ICourse
    {
        List<Course> GetAll();

        Course GetDetails(int? id);

        Course Add(Course crs);

        Course Edit(Course crs);
        Course Delete(int id);
    }
}
