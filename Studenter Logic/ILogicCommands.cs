using Studenter.Logic.Entities;

namespace Studenter.Logic
{
    public interface ILogicCommands
    {
        int CreateStudent(Student student);
        int DeleteStudent(Student student);
        int UpdateStudent(Student student);
    }
}
