using System.Windows;
using Studenter.Logic;

namespace Studenter.Presentation.Views
{
    /// <summary>
    /// Interaktionslogik für MainView.xaml
    /// </summary>
    public partial class MainView : Window, IDialog
    {
        private AboutView aboutView;
        private CreateStudentView createStudentView;

        internal MainView(AboutView aboutView, CreateStudentView createStudentView) {
            InitializeComponent();

            this.aboutView = aboutView;
            this.createStudentView = createStudentView;
        }

        private void OnAboutClick(object sender, RoutedEventArgs e) {
            aboutView.ShowDialog();
        }

        private void OnCreateStudentClick(object sender, RoutedEventArgs e) {
            createStudentView.ShowDialog();
        }
    }
}
