using Lec1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lec1.Services
{
    public interface IDepartment
    {
        List<Department> GetAll();

        Department GetDetails(int? id);

        Department Add(Department dept);

        Department Edit(Department dept);
        Department Delete(int id);
    }
}
