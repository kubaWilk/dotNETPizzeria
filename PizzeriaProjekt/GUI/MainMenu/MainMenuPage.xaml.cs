using System;
using System.Collections.Generic;
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

namespace PizzeriaProjekt.GUI.MainMenu
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }


        private void MainMenuLogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            NavigationService.Navigate(loginWindow);
        }

        private void OrderPizza_Click(object sender, RoutedEventArgs e)
        {
            PizzaOrderPage pizzaOrderPage = new PizzaOrderPage();
            NavigationService.Navigate(pizzaOrderPage);
        }

        private void OrderArchive_Click(object sender, RoutedEventArgs e)
        {
            OrderHistoryPage orderHistoryPage = new OrderHistoryPage();
            NavigationService.Navigate(orderHistoryPage);
        }
    }
}
