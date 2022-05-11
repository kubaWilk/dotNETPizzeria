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
    }
}
