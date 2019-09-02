using System.Windows;
using Studenter.Logic;

namespace Studenter.Presentation.Views
{
    /// <summary>
    /// Interaktionslogik für CreateStudentView.xaml
    /// </summary>
    public partial class CreateStudentView : Window, IDialog
    {
        internal CreateStudentView() {
            InitializeComponent();

            this.Closing += OnClosing;
        }

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e) {
            this.Hide();

            e.Cancel = true;
        }
    }
}
