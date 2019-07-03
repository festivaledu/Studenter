using Studenter.Logic.Commands;

namespace Studenter.Logic.Factories
{
    public static class LogicCommandsFactory
    {
        public static ILogicCommands CreateInstance(IDataWriter writer) => new LogicCommands(writer);
    }
}
