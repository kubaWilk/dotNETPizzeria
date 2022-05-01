using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Point = System.Windows.Point;

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
            testbox.Text = File.ReadAllText(@"Rules.txt");
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