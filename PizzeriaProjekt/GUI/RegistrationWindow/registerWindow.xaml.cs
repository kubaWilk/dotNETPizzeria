using System.Windows;
using System.Windows.Media;
using MahApps.Metro.Controls;

namespace PizzeriaProjekt
{

    public partial class registerWindow : MetroWindow
    {
      
        public registerWindow()
        {
            InitializeComponent();
        }
      
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RulesFrame.Content = new welcomePage();
            TitleBarHeight = 20;
            WindowTitleBrush = new SolidColorBrush(Colors.White);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            loginWindow loginWindow = new loginWindow();
            loginWindow.Show();
            App.Current.MainWindow.Close();
        }
    }
}

