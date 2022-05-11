using PizzeriaServer;
using PizzeriaServer.Model;
using PizzeriaServer.Orders;
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

namespace PizzeriaProjekt.GUI.MainMenu.OrderHistory
{
    /// <summary>
    /// Logika interakcji dla klasy OrderHistoryPage.xaml
    /// </summary>
    public partial class OrderHistoryPage : Page
    {
        OrderFacade orderFacade;
        User currentUser;
        public OrderHistoryPage()
        {
            InitializeComponent();
            orderFacade = new OrderFacade();
            currentUser = CurrentUserContainer.s_currentUser;

            loadOrdersIntoOrderList();
        }

        private void loadOrdersIntoOrderList()
        {
            List<PizzaOrder> pizzaOrders = orderFacade.GetUserOrderHistory(currentUser.Id);

            foreach(PizzaOrder pizzaOrder in pizzaOrders)
            {
                ordersListBox.Items.Add($"Zamówienie nr {pizzaOrder.OrderId} z {pizzaOrder.CreatedAt}");
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
                string[] temp = orderID.Split(' ');

                PizzaOrder pizzaOrderTemp = orderFacade.GetOrderById(long.Parse(temp[2]));

                selectedOrderPage selectedOrderPage = new selectedOrderPage(pizzaOrderTemp);
                NavigationService.Navigate(selectedOrderPage);
            }
            else
            {
                return;
            }

        }
    }
}
