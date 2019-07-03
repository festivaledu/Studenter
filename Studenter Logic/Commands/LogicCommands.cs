using Studenter.Logic.Entities;

namespace Studenter.Logic.Commands
{
    internal class LogicCommands : ILogicCommands
    {
        private readonly IDataWriter writer;

        internal LogicCommands(IDataWriter writer) {
            this.writer = writer;
        }

        public int CreateStudent(Student student) => writer.CreateStudent(student);

        public int DeleteStudent(Student student) => writer.DeleteStudent(student.Id);

        public int UpdateStudent(Student student) => writer.UpdateStudent(student.Id, student.Address, student.Faculty, student.Course);
    }
}
