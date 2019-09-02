using Studenter.Logic;
using Studenter.Logic.Entities;

namespace Studenter.Presentation.Services
{
    internal class CreateStudentService
    {
        private readonly ILogicCommands logicCommands;

        public CreateStudentService(ILogicCommands logicCommands) {
            this.logicCommands = logicCommands;
        }

        public void CreateStudent(Student student) {
            logicCommands.CreateStudent(student);
        }

        public void UpdateStudent(Student student) {
            logicCommands.UpdateStudent(student);
        }
    }
}
