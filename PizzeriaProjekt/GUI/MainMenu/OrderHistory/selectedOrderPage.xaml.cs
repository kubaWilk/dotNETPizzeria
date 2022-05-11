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
    /// Logika interakcji dla klasy selectedOrderPage.xaml
    /// </summary>
    public partial class selectedOrderPage : Page
    {
        private readonly PizzaOrder pizzaOrder;
        public selectedOrderPage(PizzaOrder pizzaOrder)
        {
            InitializeComponent();
            this.pizzaOrder = pizzaOrder;
            titleLabel.Content = $"ZAMÓWIENIE NR {pizzaOrder.OrderId}";
            whoLabel.Content += $" {pizzaOrder.User.FirstName} {pizzaOrder.User.LastName}";
            phoneLabel.Content += $" {pizzaOrder.User.PhoneNumber}";
            streetLabel.Content = $"{pizzaOrder.User.Street}";
            postCodeLabel.Content = $"{pizzaOrder.User.PostCode}";
            cityLabel.Content = $"{pizzaOrder.User.City}";
            dateLabel.Content += $" {pizzaOrder.CreatedAt}";
            notesTextBox.Text = $" {pizzaOrder.UserNotes}";
            if (pizzaOrder.IsDone)
            {
                statusLabel.Content += " zrealizowane";
            }
            else
            {
                statusLabel.Content += " w realizacji";
            }
            summaryLabel.Content += $"{pizzaOrder.ActualPrice}";

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
