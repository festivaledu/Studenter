using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using Studenter.Logic;
using Studenter.Logic.Entities;
using Studenter.Presentation.Helpers;
using Studenter.Presentation.ViewModels;

namespace Studenter.Presentation.Views
{
    /// <summary>
    /// Interaktionslogik für SearchResultsView.xaml
    /// </summary>
    public partial class SearchResultsView : Window, IDialog
    {
        private readonly List<string> disallowEditOn = new List<string>() { nameof(Student.Email), nameof(Student.FamilyName), nameof(Student.GivenName), nameof(Student.Id), nameof(Student.MatrikelNumber) };
        private readonly SearchResultsViewModel viewModel;

        internal SearchResultsView(SearchResultsViewModel viewModel) {
            InitializeComponent();

            this.viewModel = viewModel;
            DataContext = this.viewModel;
            
            Closing += OnClosing;
            SourceInitialized += OnSourceInitialized;
        }

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e) {
            Hide();

            e.Cancel = true;
        }

        private void OnDataGridLoaded(object sender, RoutedEventArgs e) {
            ((DataGrid) sender).ItemsSource = viewModel.Students;
        }

        private void OnDataGridPreparingCellForEdit(object sender, DataGridPreparingCellForEditEventArgs e) {
            if (disallowEditOn.Contains(e.Column.Header.ToString())) {
                e.EditingElement.IsEnabled = false;
            }
        }

        private void OnDataGridSelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (((DataGrid) sender).SelectedItem == null) {
                viewModel.SelectedStudent = null;
                return;
            }

            viewModel.SelectedStudent = ((DataGrid) sender).SelectedItem as Student;
        }

        private void OnDeleteClick(object sender, RoutedEventArgs e) {
            if (viewModel.SelectedStudent == null) {
                return;
            }

            if (MessageBox.Show($"Möchten Sie den Studenten {viewModel.SelectedStudent.MatrikelNumber} wirklich exmatrikulieren?", "Studenter", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                viewModel.Delete();

                Hide();
            }
        }

        private void OnSaveClick(object sender, RoutedEventArgs e) {
            viewModel.Save();
        }

        private void OnSourceInitialized(object sender, System.EventArgs e) {
            var windowHandle = new WindowInteropHelper(this).Handle;
            WinHandler.DisableMinimizeAndMaximizeButton(windowHandle);
        }
    }
}
