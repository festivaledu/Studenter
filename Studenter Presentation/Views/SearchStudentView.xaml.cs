using System.Windows;
using Studenter.Logic;
using Studenter.Presentation.ViewModels;

namespace Studenter.Presentation.Views
{
    /// <summary>
    /// Interaktionslogik für SearchStudentView.xaml
    /// </summary>
    public partial class SearchStudentView : Window, IDialog
    {
        private readonly SearchStudentViewModel viewModel;

        internal SearchStudentView(SearchStudentViewModel viewModel) {
            InitializeComponent();

            this.viewModel = viewModel;
            DataContext = this.viewModel;

            Closing += OnClosing;
            IsVisibleChanged += OnIsVisibleChanged;
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

        private void OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) {
            if ((bool) e.NewValue) {
                _ = this.viewModel.Faculties;
            }
        }

        private void OnSearchClick(object sender, RoutedEventArgs e) {
            viewModel.Send();

            Hide();
        }


    }
}
