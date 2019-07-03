using System;
using System.Data.Common;
using Studenter.Data.Writers;
using Studenter.Logic;

namespace Studenter.Data.Factories
{
    public static class DataWriterFactory
    {
        public static IDataWriter CreateInstance(string dataSourcePath) {
            var providerFactory = DbProviderFactories.GetFactory("System.Data.OleDb") ?? throw new ApplicationException("Could not create System.Data.OleDb.");
            var connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dataSourcePath};";

            return new AccessDataWriter(providerFactory, connectionString) ?? throw new ApplicationException("Could not create DataWriter.");
        }
    }
}
