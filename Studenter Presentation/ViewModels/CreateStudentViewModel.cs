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
                this.OnPropertyChanged("Address");
            }
        }

        public string Course {
            get => student.Course;
            set {
                student.Course = value;
                this.OnPropertyChanged("Course");
            }
        }

        public string Email {
            get => student.Email;
            set {
                student.Email = value;
                this.OnPropertyChanged("Email");
            }
        }

        public string Faculty {
            get => student.Faculty;
            set {
                student.Faculty = value;
                this.OnPropertyChanged("Faculty");
            }
        }

        public string FamilyName {
            get => student.FamilyName;
            set {
                student.FamilyName = value;
                this.OnPropertyChanged("FamilyName");
            }
        }

        public string GivenName {
            get => student.GivenName;
            set {
                student.GivenName = value;
                this.OnPropertyChanged("GivenName");
            }
        }

        public int MatrikelNumber {
            get => student.MatrikelNumber;
            set {
                student.MatrikelNumber = value;
                this.OnPropertyChanged("MatrikelNumber");
            }
        }

        public CreateStudentViewModel(CreateStudentService service) {
            this.service = service;
            this.student = new Student();
        }

        public void Clear() {
            this.student = new Student();
        }

        public void Send() {
            service.CreateStudent(student);
            this.Clear();
        }
    }
}
