using Studenter.Logic.Entities;

namespace Studenter.Logic
{
    public interface IDataWriter
    {
        void InitDb();
        void CloseDb();
        int CreateStudent(Student student);
        int DeleteStudent(string id);
        int UpdateStudent(string id, string address, string faculty, string course);
    }
}
