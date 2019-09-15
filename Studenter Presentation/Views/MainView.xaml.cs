using System.Windows;
using Studenter.Logic;
using Studenter.Presentation.ViewModels;

namespace Studenter.Presentation.Views
{
    /// <summary>
    /// Interaktionslogik für MainView.xaml
    /// </summary>
    public partial class MainView : Window, IDialog
    {
        private readonly MainViewModel viewModel;

        private readonly AboutView aboutView;
        private readonly CreateStudentView createStudentView;
        private readonly SearchResultsView searchResultsView;
        private readonly SearchStudentView searchStudentView;

        internal MainView(MainViewModel viewModel, AboutView aboutView, CreateStudentView createStudentView, SearchResultsView searchResultsView, SearchStudentView searchStudentView) {
            InitializeComponent();

            this.viewModel = viewModel;
            DataContext = this.viewModel;

            this.aboutView = aboutView;
            this.createStudentView = createStudentView;
            this.searchResultsView = searchResultsView;
            this.searchStudentView = searchStudentView;

            Closing += OnClosing;
        }

        private void OnAboutClick(object sender, RoutedEventArgs e) {
            aboutView.ShowDialog();
        }

        private void OnCloseClick(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e) {
            Application.Current.Shutdown();
        }

        private void OnCreateStudentClick(object sender, RoutedEventArgs e) {
            createStudentView.ShowDialog();
        }

        private void OnSearchStudentClick(object sender, RoutedEventArgs e) {
            searchStudentView.ShowDialog();

            if (!viewModel.SearchCancelled) {
                ((SearchResultsViewModel) searchResultsView.DataContext).Students = viewModel.Results;
                searchResultsView.ShowDialog();
            }
        }
    }
}
