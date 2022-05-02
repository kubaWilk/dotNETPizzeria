using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace PizzeriaProjekt
{
    public partial class welcomePage : Page
    {
        public welcomePage()
        {
            InitializeComponent();
        }

        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }

        private void ProceedButton__Click(object sender, RoutedEventArgs e)
        {
            rulesPage rulesPage = new rulesPage();
            NavigationService.Navigate(rulesPage);
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            loginWindow loginWindow = new loginWindow();
            loginWindow.Show();
            App.Current.MainWindow.Close();
        }

    }
}
