using System.Windows;
using Studenter.Logic;
using Studenter.Presentation.ViewModels;

namespace Studenter.Presentation.Views
{
    /// <summary>
    /// Interaktionslogik für CreateStudentView.xaml
    /// </summary>
    public partial class CreateStudentView : Window, IDialog
    {
        private readonly CreateStudentViewModel viewModel;

        internal CreateStudentView(CreateStudentViewModel viewModel) {
            InitializeComponent();

            this.viewModel = viewModel;
            DataContext = this.viewModel;

            Closing += OnClosing;
        }

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e) {
            viewModel.Clear();

            Hide();

            e.Cancel = true;
        }

        private void OnCancelClick(object sender, RoutedEventArgs e) {
            viewModel.Clear();

            Hide();
        }

        private void OnCreateClick(object sender, RoutedEventArgs e) {
            viewModel.Send();

            Hide();
        }
    }
}
