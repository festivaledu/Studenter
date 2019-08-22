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

        internal MainView(AboutView aboutView) {
            InitializeComponent();

            this.aboutView = aboutView;
        }

        private void OnAboutClick(object sender, RoutedEventArgs e) {
            aboutView.ShowDialog();
        }
    }
}
