using System.Windows;
using MessageControl;

namespace GNW.ILS.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += mainwindow_Closing;
            Common.GdBodyContent = GdBodyContent;
            Common.BtnLogout = BtnLogout;
            ContentPanel.MessageControllerStackPanel = MessageControllerStackPanel;
            Common.AddView(new LoggingView());
        }

        private void mainwindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (CustomMessageBox.Show("Do You Want to Exit the Application?", "Exiting?", winMessageBox.buttonPanel.YESNO, winMessageBox.icon.Question) == winMessageBox.userResult.YES)
            //{
            //    Environment.Exit(0);
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
        }

        private void BtnLogout_OnClick(object sender, RoutedEventArgs e)
        {
            Common.FlowView.Pop();
            Common.AddView(new LoggingView());
            Common.BtnLogout.Visibility = Visibility.Collapsed;
        }
    }
}
