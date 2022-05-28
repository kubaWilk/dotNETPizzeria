using PizzeriaServer;
using PizzeriaServer.Model;
using PizzeriaServer.Orders;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace PizzeriaProjekt.GUI.MainMenu.OrderHistory
{
    /// <summary>
    /// Logika interakcji dla klasy OrderHistoryPage.xaml
    /// </summary>
    public partial class OrderHistoryPage : Page
    {
        private OrderFacade orderFacade;
        private User currentUser;

        public OrderHistoryPage()
        {
            InitializeComponent();
            orderFacade = new OrderFacade();
            currentUser = CurrentUserContainer.s_currentUser;

            loadOrdersIntoOrderList();
        }

        private void loadOrdersIntoOrderList()
        {
            try 
            {
                List<PizzaOrder> pizzaOrders = orderFacade.GetUserOrderHistory(currentUser.Id);

                if (pizzaOrders.Count <= 0)
                {
                    return;
                }

                foreach (PizzaOrder pizzaOrder in pizzaOrders)
                {
                    ordersListBox.Items.Add($"Zamówienie nr {pizzaOrder.OrderId} z {pizzaOrder.CreatedAt}");
                }
            }
            catch (MySqlConnector.MySqlException)
            {
                System.Windows.Forms.MessageBox.Show("Wystąpił błąd połączenia z bazą danych!");
            }
        }

    private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void chooseButton_Click(object sender, RoutedEventArgs e)
        {
            string orderID = string.Empty;

            if (ordersListBox.SelectedItem != null)
            {
                orderID = ordersListBox.SelectedItem.ToString();
                string[] orderIDSplit = orderID.Split(' ');

                PizzaOrder pizzaOrderTemp = orderFacade.GetOrderById(long.Parse(orderIDSplit[2]));

                selectedOrderPage selectedOrderPage = new selectedOrderPage(pizzaOrderTemp);
                NavigationService.Navigate(selectedOrderPage);
            }
            else
            {
                return;
            }
        }

        private void ordersListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ordersListBox.SelectedItem == null) return;
            else
            {
                chooseButton_Click(sender, e);
            }
        }
    }
}
