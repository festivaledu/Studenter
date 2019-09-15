using System.Collections.ObjectModel;
using Studenter.Logic.Entities;
using Studenter.Presentation.Services;

namespace Studenter.Presentation.ViewModels
{
    internal class SearchResultsViewModel : BaseViewModel
    {
        private readonly CreateStudentService createService;
        private readonly MainViewModel mainViewModel;
        private readonly SearchStudentService searchService;
        private Student selectedStudent;
        private ObservableCollection<Student> students;

        public Student SelectedStudent {
            get => selectedStudent;
            set {
                selectedStudent = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(StudentSelected));
            }
        }

        public bool StudentSelected => SelectedStudent != null;
        public ObservableCollection<Student> Students {
            get => students = mainViewModel.Results;
            set {
                students = value;
                OnPropertyChanged();
            }
        }

        public SearchResultsViewModel(MainViewModel mainViewModel, CreateStudentService createService, SearchStudentService searchService) {
            this.mainViewModel = mainViewModel;
            this.createService = createService;
            this.searchService = searchService;
        }

        internal void Delete() {
            if (SelectedStudent != null) {
                createService.DeleteStudent(SelectedStudent);
                mainViewModel.StudentCount = searchService.CountStudents();
            }
        }

        internal void Save() {
            if (SelectedStudent != null) {
                createService.UpdateStudent(SelectedStudent);
            }
        }
    }
}
