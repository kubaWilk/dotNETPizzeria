using System.Windows;
using System.Windows.Media;
using MahApps.Metro.Controls;

namespace PizzeriaProjekt
{

    public partial class registerWindow : MetroWindow
    {
      
        public registerWindow()
        {
            TitleBarHeight = 20;
            InitializeComponent();
        }
      
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RulesFrame.Content = new welcomePage();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            loginWindow loginWindow = new loginWindow();
            loginWindow.Show();
            App.Current.MainWindow.Close();
        }
    }
}

