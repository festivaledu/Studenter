using System.Collections.Generic;
using System.Data.Common;
using Studenter.Logic;
using Studenter.Logic.Entities;
using Studenter.Logic.TransferObjects;

namespace Studenter.Data.Readers
{
    internal abstract class DataReader : DbConnector, IDataReader
    {
        protected DataReader(DbProviderFactory providerFactory, string connectionString) : base(providerFactory, connectionString) { }

        public int CountStudents() {
            var count = 0;

            if (OpenConnection()) {
                command.CommandText = "SELECT COUNT(*) FROM Students;";

                var result = command.ExecuteScalar();
                count = (int) result;
            }
            CloseConnection();

            return count;
        }

        public ICollection<string> ReadCourses(string faculty) {
            var courses = new List<string>();

            if (OpenConnection()) {
                command.CommandText = "SELECT DISTINCT Course FROM Students WHERE Faculty = ? ORDER BY Course;";
                command.Parameters.Clear();

                AddParameter(command, "Faculty", faculty);

                var reader = command.ExecuteReader();
                if (reader != null) {
                    while (reader.Read()) {
                        courses.Add(reader[0].ToString());
                    }

                    if (!reader.IsClosed) {
                        reader.Close();
                    }
                }
            }
            CloseConnection();

            return courses;
        }

        public ICollection<string> ReadFaculties() {
            var faculties = new List<string>();

            if (OpenConnection()) {
                command.CommandText = "SELECT DISTINCT Faculty FROM Students ORDER BY Faculty;";

                var reader = command.ExecuteReader();
                if (reader != null) {
                    while (reader.Read()) {
                        faculties.Add(reader[0].ToString());
                    }

                    if (!reader.IsClosed) {
                        reader.Close();
                    }
                }
            }
            CloseConnection();

            return faculties;
        }

        public Student ReadStudent(string id) {
            Student student = null;

            if (OpenConnection()) {
                command.CommandText = "SELECT * FROM Students WHERE Id = ?;";
                command.Parameters.Clear();

                AddParameter(command, "Id", id);

                var reader = command.ExecuteReader();
                if (reader != null) {
                    while (reader.Read()) {
                        student = new Student(reader);
                    }

                    if (!reader.IsClosed) {
                        reader.Close();
                    }
                }
            }
            CloseConnection();

            return student;
        }

        public ICollection<Student> ReadStudents(StudentSearchDto search) {
            var students = new List<Student>();

            if (OpenConnection()) {
                command.CommandText = "SELECT * FROM Students WHERE " +
                    "GivenName = @GivenName AND " +
                    "FamilyName = @FamilyName AND " +
                    "Address = @Address AND " +
                    "Email = @Email AND " +
                    "MatrikelNumber = @MatrikelNumber AND " +
                    "Faculty = @Faculty AND " +
                    "Course = @Course;";

                command.Parameters.Clear();

                AddParameter(command, "@GivenName", search.GivenName);
                AddParameter(command, "@FamilyName", search.FamilyName);
                AddParameter(command, "@Address", search.Address);
                AddParameter(command, "@Email", search.Email);
                AddParameter(command, "@MatrikelNumber", search.MatrikelNumber);
                AddParameter(command, "@Faculty", search.Faculty);
                AddParameter(command, "@Course", search.Course);

                var reader = command.ExecuteReader();
                if (reader != null) {
                    while (reader.Read()) {
                        students.Add(new Student(reader));
                    }

                    if (!reader.IsClosed) {
                        reader.Close();
                    }
                }
            }
            CloseConnection();

            return students;
        }
    }
}
