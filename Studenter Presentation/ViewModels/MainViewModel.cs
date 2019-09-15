using System.Collections.ObjectModel;
using Studenter.Logic.Entities;
using Studenter.Logic.TransferObjects;
using Studenter.Presentation.Services;

namespace Studenter.Presentation.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private ObservableCollection<Student> results = new ObservableCollection<Student>();
        private StudentSearchDto search;
        private int studentCount;

        public ObservableCollection<Student> Results {
            get => results;
            set {
                results = value;
                OnPropertyChanged();
            }
        }

        public StudentSearchDto Search {
            get => search;
            set {
                search = value;
                OnPropertyChanged();
            }
        }

        public bool SearchCancelled { get; set; }

        public int StudentCount {
            get => studentCount;
            set {
                studentCount = value;
                OnPropertyChanged();
            }
        }

        internal MainViewModel(SearchStudentService service) {
            this.studentCount = service.CountStudents();
        }
    }
}
