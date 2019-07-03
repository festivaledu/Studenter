using System.Collections.Generic;
using Studenter.Logic.Entities;
using Studenter.Logic.TransferObjects;

namespace Studenter.Logic.Queries
{
    internal class LogicQueries : ILogicQueries
    {
        private readonly IDataReader reader;

        internal LogicQueries(IDataReader reader) {
            this.reader = reader;
        }

        public int CountStudents() => reader.CountStudents();

        public ICollection<Student> FindStudent(StudentSearchDto search) => reader.ReadStudents(search);

        public ICollection<string> GetCourses(string faculty) => reader.ReadCourses(faculty);

        public ICollection<string> GetFaculties() => reader.ReadFaculties();

        public Student GetStudent(string id) => reader.ReadStudent(id);
    }
}
