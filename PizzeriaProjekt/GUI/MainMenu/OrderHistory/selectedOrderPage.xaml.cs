using PizzeriaServer.Meals.Models;
using PizzeriaServer.Orders;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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

            setCustomerData();
            setOrderItems();
        }   

        private void setCustomerData()
        {
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
            summaryLabel.Content += $"{pizzaOrder.ActualPrice}zł";
        }

        private void setOrderItems()
        {
            foreach (PizzaOrder.Item item in pizzaOrder.Items)
            {
                TreeViewItem root = new TreeViewItem() { Header = $"{item.Pizza.Name}" };

                root.Items.Add(new TreeViewItem() { Header = $"Rodzaj Ciasta: {item.Crust.Name} ({item.Crust.BasePrice}zł)" });
                root.Items.Add(new TreeViewItem() { Header = $"Rozmiar: {item.Size.Name} ({item.Size.BasePrice}zł)" });

                TreeViewItem toppingsNode = new TreeViewItem() { Header = "Składniki" };

                foreach (PizzaTopping topping in item.Pizza.PizzaToppings)
                {
                    toppingsNode.Items.Add(new TreeViewItem() { Header = $"{topping.Topping.Name} {topping.Topping.BasePrice}zł" });
                }

                foreach (Topping topping in item.ExtraToppings)
                {
                    toppingsNode.Items.Add(new TreeViewItem() { Header = $"{topping.Name} ({topping.BasePrice}zł)" });
                }

                root.Items.Add(toppingsNode);
                root.Items.Add(new TreeViewItem() { Header = $"Łączna cena: ({item.ActualPrice}zł)" });

                orderItemsTreeView.Items.Add(root);
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
