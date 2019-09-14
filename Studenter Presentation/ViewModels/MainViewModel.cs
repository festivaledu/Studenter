using System.Collections.ObjectModel;
using Studenter.Logic.Entities;
using Studenter.Logic.TransferObjects;

namespace Studenter.Presentation.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private ObservableCollection<Student> results = new ObservableCollection<Student>();
        private StudentSearchDto search;

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

        internal MainViewModel() {}
    }
}
