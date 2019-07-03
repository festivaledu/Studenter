using System;
using System.Data.Common;

namespace Studenter.Logic.Entities
{
    public class Student
    {
        public string Id { get; private set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int MatrikelNumber { get; set; }
        public string Faculty { get; set; }
        public string Course { get; set; }

        public Student() {
            this.Id = Guid.NewGuid().ToString();
        }

        public Student(string id, string name, string familyName, string address, string email, int matrikelNumber, string faculty, string course) {
            this.Id = id;
            this.Name = name;
            this.FamilyName = familyName;
            this.Address = address;
            this.Email = email;
            this.MatrikelNumber = matrikelNumber;
            this.Faculty = faculty;
            this.Course = course;
        }

        public Student(DbDataReader dataReader) {
            this.Id = dataReader.GetString(0);
            this.Name = dataReader.GetString(1);
            this.FamilyName = dataReader.GetString(2);
            this.Address = dataReader.GetString(3);
            this.Email = dataReader.GetString(4);
            this.MatrikelNumber = dataReader.GetInt32(5);
            this.Faculty = dataReader.GetString(6);
            this.Course = dataReader.GetString(7);
        }
    }
}
