using Lec1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lec1.Services
{
    public interface IStudent
    {
        List<Student> GetAll();

        Student GetDetails(int? id);

        Student Add(Student std);

        Student Edit(Student std);
        Student Delete(int id);


    }
}
