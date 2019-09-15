using Microsoft.VisualStudio.TestTools.UnitTesting;
using Studenter.Data.Factories;
using Studenter.Logic;
using Studenter.Logic.TransferObjects;

namespace Studenter.Tests
{
    [TestClass]
    public class DataReaderTests
    {
        private IDataReader reader;

        [TestInitialize]
        public void Initialize() {
            reader = DataReaderFactory.CreateInstance(@"G:\Studium\Komponentenbasierte Softwareentwicklung\Studenter\resources\database.accdb");
            Assert.IsNotNull(reader, "Could not instantiate the IDataReader");

            reader.InitDb();
        }

        [TestCleanup]
        public void Cleanup() {
            reader.CloseDb();
        }

        [DataTestMethod]
        [DataRow(3)]
        public void CanCountStudents(int expected) {
            Assert.AreEqual(expected, reader.CountStudents());
        }

        [DataTestMethod]
        [DataRow("Bau-Wasser-Boden", 1)]
        public void CanReadCourses(string faculty, int expected) {
            var courses = reader.ReadCourses(faculty);
            Assert.AreEqual(expected, courses.Count);
        }

        [DataTestMethod]
        [DataRow(1)]
        public void CanReadFaculties(int expected) {
            var faculties = reader.ReadFaculties();
            Assert.AreEqual(expected, faculties.Count);
        }

        [DataTestMethod]
        [DataRow("06909fe6-a227-4e07-80c8-21e30f90c01f", 70453310)]
        [DataRow("5c2a0888-41e0-43ec-a0dd-791218fa14fb", 70454016)]
        [DataRow("c9060d6f-ce4d-4c1c-ae10-4fa9dfeafa3f", 70453510)]
        public void CanReadStudent(string id, int expected) {
            var student = reader.ReadStudent(id);
            Assert.AreEqual(expected, student.MatrikelNumber);
        }

        [DataTestMethod]
        [DataRow("Angewandte Informatik", 3)]
        [DataRow("Soziale Arbeit", 0)]
        public void CanReadStudents(string course, int expected) {
            var search = new StudentSearchDto() {
                Course = course
            };

            var students = reader.ReadStudents(search);
            Assert.AreEqual(expected, students.Count);
        }
    }
}
