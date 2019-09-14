using System;
using System.Data;
using System.Data.Common;

namespace Studenter.Data
{
    internal class DbConnector
    {
        protected DbCommand command;
        protected DbConnection connection;
        protected DbTransaction transaction;

        private readonly string connectionString;
        private readonly DbProviderFactory providerFactory;

        protected DbConnector(DbProviderFactory providerFactory, string connectionString) {
            if (string.IsNullOrEmpty(connectionString)) {
                throw new ApplicationException("connectionString cannot be empty.");
            }

            this.providerFactory = providerFactory ?? throw new ApplicationException("providerFactory cannot be null.");
            this.connectionString = connectionString;
        }

        protected static void AddParameter(DbCommand command, string parameterName, object parameterValue) {
            var parameter = command.CreateParameter();

            parameter.ParameterName = parameterName;
            parameter.Value = parameterValue;

            command.Parameters.Add(parameter);
        }

        public virtual void CloseDb() {
            CloseConnection();
        }

        public virtual void InitDb() {
            connection = providerFactory.CreateConnection() ?? throw new ApplicationException("Could not create connection.");
            connection.ConnectionString = connectionString;
            
            connection.Open();
            if (connection.State == ConnectionState.Open) {
                connection.Close();
            } else {
                throw new ApplicationException($"Could not connect to {connectionString}.");
            }

            command = providerFactory.CreateCommand() ?? throw new ApplicationException("Could not create command.");
            command.CommandType = CommandType.Text;
            command.Connection = connection;
        }

        protected void CloseConnection() {
            if (connection.State == ConnectionState.Open) {
                connection.Close();
            }
        }

        protected virtual bool OpenConnection() {
            connection.Open();

            return connection.State == ConnectionState.Open;
        }
    }
}
