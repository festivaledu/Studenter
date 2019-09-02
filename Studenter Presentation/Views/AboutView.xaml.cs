using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Interop;
using Studenter.Logic;
using Studenter.Presentation.Helpers;

namespace Studenter.Presentation.Views
{
    /// <summary>
    /// Interaktionslogik für AboutView.xaml
    /// </summary>
    public partial class AboutView : Window, IDialog
    {
        internal AboutView() {
            InitializeComponent();

            this.Closing += OnClosing;
        }

        private void OnClosing(object sender, CancelEventArgs e) {
            this.Hide();

            e.Cancel = true;
        }

        private void OnSourceInitialized(object sender, EventArgs e) {
            var windowHandle = new WindowInteropHelper(this).Handle;
            WinHandler.DisableMinimizeAndMaximizeButton(windowHandle);
        }
    }
}
