using Studenter.Logic.Entities;
using Studenter.Presentation.Services;

namespace Studenter.Presentation.ViewModels
{
    class CreateStudentViewModel : BaseViewModel
    {
        private readonly CreateStudentService service;
        private Student student;

        public string Address {
            get => student.Address;
            set {
                student.Address = value;
                OnPropertyChanged("Address");
            }
        }

        public string Course {
            get => student.Course;
            set {
                student.Course = value;
                OnPropertyChanged("Course");
            }
        }

        public string Email {
            get => student.Email;
            set {
                student.Email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Faculty {
            get => student.Faculty;
            set {
                student.Faculty = value;
                OnPropertyChanged("Faculty");
            }
        }

        public string FamilyName {
            get => student.FamilyName;
            set {
                student.FamilyName = value;
                OnPropertyChanged("FamilyName");
            }
        }

        public string GivenName {
            get => student.GivenName;
            set {
                student.GivenName = value;
                OnPropertyChanged("GivenName");
            }
        }

        public int MatrikelNumber {
            get => student.MatrikelNumber;
            set {
                student.MatrikelNumber = value;
                OnPropertyChanged("MatrikelNumber");
            }
        }

        public CreateStudentViewModel(CreateStudentService service) {
            this.service = service;
            student = new Student();
        }

        internal void Clear() {
            student = new Student();
        }

        internal void Send() {
            service.CreateStudent(student);
            Clear();
        }
    }
}
