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
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT COUNT(*) FROM Students;";
                command.Parameters.Clear();

                var result = command.ExecuteScalar();
                count = (int) result;
            }
            CloseConnection();

            return count;
        }

        public ICollection<string> ReadCourses(string faculty) {
            var courses = new List<string>();

            if (OpenConnection()) {
                command.CommandType = System.Data.CommandType.Text;
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
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT Faculty FROM Students GROUP BY Faculty ORDER BY Faculty;";
                command.Parameters.Clear();

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
                command.CommandType = System.Data.CommandType.Text;
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
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.Clear();
                command.CommandText = "SELECT * FROM Students WHERE ";

                if (!string.IsNullOrEmpty(search.Address)) {
                    command.CommandText += "Address = @Address AND ";
                    AddParameter(command, "@Address", search.Address);
                }

                if (!string.IsNullOrEmpty(search.Course)) {
                    command.CommandText += "Course = @Course AND ";
                    AddParameter(command, "@Course", search.Course);
                }

                if (!string.IsNullOrEmpty(search.Email)) {
                    command.CommandText += "Email = @Email AND ";
                    AddParameter(command, "@Email", search.Email);
                }

                if (!string.IsNullOrEmpty(search.Faculty)) {
                    command.CommandText += "Faculty = @Faculty AND ";
                    AddParameter(command, "@Faculty", search.Faculty);
                }

                if (!string.IsNullOrEmpty(search.FamilyName)) {
                    command.CommandText += "FamilyName = @FamilyName AND ";
                    AddParameter(command, "@FamilyName", search.FamilyName);
                }

                if (!string.IsNullOrEmpty(search.GivenName)) {
                    command.CommandText += "GivenName = @GivenName AND ";
                    AddParameter(command, "@GivenName", search.GivenName);
                }

                if (search.MatrikelNumber > 0) {
                    command.CommandText += "MatrikelNumber = @MatrikelNumber AND ";
                    AddParameter(command, "@MatrikelNumber", search.MatrikelNumber);
                }

                command.CommandText = command.CommandText.Substring(0, command.CommandText.Length - 5) + ";";

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
