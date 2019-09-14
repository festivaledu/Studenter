using System.Collections.ObjectModel;
using Studenter.Logic.Entities;
using Studenter.Presentation.Services;

namespace Studenter.Presentation.ViewModels
{
    internal class SearchResultsViewModel : BaseViewModel
    {
        private MainViewModel mainViewModel;
        private Student selectedStudent;
        private CreateStudentService service;

        public Student SelectedStudent {
            get => selectedStudent;
            set {
                selectedStudent = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(StudentSelected));
            }
        }

        public bool StudentSelected => SelectedStudent != null;
        public ObservableCollection<Student> Students => mainViewModel.Results;

        public SearchResultsViewModel(MainViewModel mainViewModel, CreateStudentService service) {
            this.mainViewModel = mainViewModel;
            this.service = service;
        }

        internal void Delete() {
            if (SelectedStudent != null) {
                service.DeleteStudent(SelectedStudent);
            }
        }

        internal void Save() {
            if (SelectedStudent != null) {
                service.UpdateStudent(SelectedStudent);
            }
        }
    }
}
