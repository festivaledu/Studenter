using System.Data.Common;

namespace Studenter.Data.Readers
{
    internal class AccessDataReader : DataReader
    {
        internal AccessDataReader(DbProviderFactory providerFactory, string connectionString) : base(providerFactory, connectionString) { }
    }
}
