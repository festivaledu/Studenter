using Studenter.Logic.Queries;

namespace Studenter.Logic.Factories
{
    public static class LogicQueriesFactory
    {
        public static ILogicQueries CreateInstance(IDataReader reader) => new LogicQueries(reader);
    }
}
