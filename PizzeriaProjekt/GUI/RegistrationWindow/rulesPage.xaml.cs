using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace PizzeriaProjekt
{
    public partial class rulesPage : Page
    {
        public rulesPage()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 250);
            dispatcherTimer.Start();

            System.Windows.Forms.MessageBox.Show(AppDomain.CurrentDomain.BaseDirectory);
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (testbox.GetLastVisibleLineIndex() == 86)
            {
                Accepted.IsEnabled = true;
            }
            else
                Accepted.IsEnabled = false;
        }
        private void Accepted_Click(object sender, RoutedEventArgs e)
        {
            dataPage data = new dataPage();
            this.NavigationService.Navigate(data);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                testbox.Text = File.ReadAllText(@"GUI\RegistrationWindow\Rules.txt");
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                Accepted.IsEnabled = true;
                testbox.Text = "błąd odczytu pliku";
               
            }

            Accepted.IsEnabled = false;
        }

        private void noAccepted_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            loginWindow loginWindow = new loginWindow();
            loginWindow.Show();
            App.Current.MainWindow.Close();
        }
    }
}