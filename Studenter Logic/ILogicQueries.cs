using System.Collections.Generic;
using Studenter.Logic.Entities;
using Studenter.Logic.TransferObjects;

namespace Studenter.Logic
{
    public interface ILogicQueries
    {
        int CountStudents();
        ICollection<string> GetCourses(string faculty);
        ICollection<string> GetFaculties();
        Student GetStudent(string id);
        ICollection<Student> FindStudent(StudentSearchDto search);
    }
}
