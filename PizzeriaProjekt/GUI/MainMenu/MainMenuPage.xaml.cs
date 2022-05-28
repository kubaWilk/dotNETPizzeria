using PizzeriaProjekt.GUI.MainMenu.OrderHistory;
using PizzeriaServer.Users;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PizzeriaProjekt.GUI.MainMenu
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        private Window _parentWindow;
        public MainMenuPage(Window parent)
        {
            InitializeComponent();
            _parentWindow = parent;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }


        private void MainMenuLogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            UserFacade userFacade = new UserFacade();
            userFacade.LogOut();

            loginWindow loginWindow = new loginWindow();
            _parentWindow.Hide();
            loginWindow.Show();
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
