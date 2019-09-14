using System.Collections.ObjectModel;
using Studenter.Logic.TransferObjects;
using Studenter.Presentation.Services;

namespace Studenter.Presentation.ViewModels
{
    internal class SearchStudentViewModel : BaseViewModel
    {
        private MainViewModel mainViewModel;
        private readonly SearchStudentService service;
        private StudentSearchDto search;

        public ObservableCollection<string> Courses { get; private set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Faculties => service.GetFaculties();

        public string SelectedAddress {
            get => search.Address;
            set {
                search.Address = value;
                OnPropertyChanged();
            }
        }

        public string SelectedCourse {
            get => search.Course;
            set {
                search.Course = value;
                OnPropertyChanged();
            }
        }

        public string SelectedEmail {
            get => search.Email;
            set {
                search.Email = value;
                OnPropertyChanged();
            }
        }

        public string SelectedFaculty {
            get => search.Faculty;
            set {
                search.Faculty = value;
                OnPropertyChanged();

                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value)) {
                    Courses = service.GetCourses(value);
                    OnPropertyChanged(nameof(Courses));
                }
            }
        }

        public string SelectedFamilyName {
            get => search.FamilyName;
            set {
                search.FamilyName = value;
                OnPropertyChanged();
            }
        }

        public string SelectedGivenName {
            get => search.GivenName;
            set {
                search.GivenName = value;
                OnPropertyChanged();
            }
        }

        public int SelectedMatrikelNumber {
            get => search.MatrikelNumber;
            set {
                search.MatrikelNumber = value;
                OnPropertyChanged();
            }
        }

        public SearchStudentViewModel(MainViewModel mainViewModel, SearchStudentService service) {
            this.mainViewModel = mainViewModel;
            search = new StudentSearchDto();
            this.service = service;
        }

        internal void Clear() {
            search = new StudentSearchDto();
            mainViewModel.SearchCancelled = true;
        }

        internal void Send() {
            mainViewModel.Results = service.FindStudent(search);
            mainViewModel.SearchCancelled = false;
        }
    }
}
