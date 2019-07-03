using System.Data.Common;
using Studenter.Logic;
using Studenter.Logic.Entities;

namespace Studenter.Data.Writers
{
    internal abstract class DataWriter : DbConnector, IDataWriter
    {
        protected DataWriter(DbProviderFactory providerFactory, string connectionString) : base(providerFactory, connectionString) { }

        public int CreateStudent(Student student) {
            var rowsAffected = 0;

            try {
                if (OpenConnection()) {
                    transaction = connection.BeginTransaction();

                    command.Transaction = transaction;
                    command.CommandText = "INSERT INTO Students " +
                        "(Id, GivenName, FamilyName, Address, Email, MatrikelNumber, Faculty, Course) " +
                        "VALUES(@Id, @GivenName, @FamilyName, @Address, @Email, @MatrikelNumber, @Faculty, @Course);";

                    command.Parameters.Clear();

                    AddParameter(command, "@Id", student.Id);
                    AddParameter(command, "@GivenName", student.GivenName);
                    AddParameter(command, "@FamilyName", student.FamilyName);
                    AddParameter(command, "@Address", student.Address);
                    AddParameter(command, "@Email", student.Email);
                    AddParameter(command, "@MatrikelNumber", student.MatrikelNumber);
                    AddParameter(command, "@Faculty", student.Faculty);
                    AddParameter(command, "@Course", student.Course);

                    rowsAffected = command.ExecuteNonQuery();

                    transaction.Commit();
                }
                CloseConnection();
            } catch {
                transaction.Rollback();
                CloseConnection();
                throw;
            }

            return rowsAffected;
        }

        public int DeleteStudent(string id) {
            var rowsAffected = 0;
            
            if (OpenConnection()) {
                command.CommandText = "DELETE FROM Students WHERE Id = ?;";
                command.Parameters.Clear();

                AddParameter(command, "Id", id);

                rowsAffected = command.ExecuteNonQuery();
            }
            CloseConnection();

            return rowsAffected;
        }

        public int UpdateStudent(string id, string address, string faculty, string course) {
            var rowsAffected = 0;

            try {
                if (OpenConnection()) {
                    transaction = connection.BeginTransaction();

                    command.Transaction = transaction;
                    command.CommandText = "UPDATE Students SET " +
                        "Address = ?, Faculty = ?, Course = ? " +
                        "WHERE Id = ?;";

                    command.Parameters.Clear();

                    AddParameter(command, "Address", address);
                    AddParameter(command, "Faculty", faculty);
                    AddParameter(command, "Course", course);
                    AddParameter(command, "Id", id);

                    rowsAffected = command.ExecuteNonQuery();

                    transaction.Commit();
                }
                CloseConnection();
            } catch {
                transaction.Rollback();
                CloseConnection();
                throw;
            }

            return rowsAffected;
        }
    }
}
