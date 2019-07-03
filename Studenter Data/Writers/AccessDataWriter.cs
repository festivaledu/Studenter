using System.Data.Common;

namespace Studenter.Data.Writers
{
    internal class AccessDataWriter : DataWriter
    {
        internal AccessDataWriter(DbProviderFactory providerFactory, string connectionString) : base(providerFactory, connectionString) { }
    }
}
