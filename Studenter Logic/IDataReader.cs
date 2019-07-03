using System.Collections.Generic;
using Studenter.Logic.Entities;
using Studenter.Logic.TransferObjects;

namespace Studenter.Logic
{
    public interface IDataReader
    {
        void InitDb();
        void CloseDb();
        int CountStudents();
        ICollection<string> ReadCourses(string faculty);
        ICollection<string> ReadFaculties();
        Student ReadStudent(string id);
        ICollection<Student> ReadStudents(StudentSearchDto search);
    }
}
