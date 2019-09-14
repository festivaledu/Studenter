using System.Collections.ObjectModel;
using Studenter.Logic;
using Studenter.Logic.Entities;
using Studenter.Logic.TransferObjects;

namespace Studenter.Presentation.Services
{
    internal class SearchStudentService
    {
        private ILogicQueries logicQueries; 

        public SearchStudentService(ILogicQueries logicQueries) {
            this.logicQueries = logicQueries;
        }

        public int CountStudents() {
            return logicQueries.CountStudents();
        }

        public ObservableCollection<Student> FindStudent(StudentSearchDto search) {
            return new ObservableCollection<Student>(logicQueries.FindStudent(search));
        }

        public ObservableCollection<string> GetCourses(string faculty) {
            return new ObservableCollection<string>(logicQueries.GetCourses(faculty));
        }

        public ObservableCollection<string> GetFaculties() {
            return new ObservableCollection<string>(logicQueries.GetFaculties());
        }

        public Student GetStudent(string id) {
            return logicQueries.GetStudent(id);
        }
    }
}
