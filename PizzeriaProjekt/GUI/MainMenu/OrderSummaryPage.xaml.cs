using PizzeriaServer;
using PizzeriaServer.Meals;
using PizzeriaServer.Meals.Models;
using PizzeriaServer.Orders;
using PizzeriaServer.Users;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PizzeriaProjekt.GUI.MainMenu
{
    /// <summary>
    /// Interaction logic for OrderSummaryPage.xaml
    /// </summary>
    public partial class OrderSummaryPage : Page
    {
        private MealFacade mealFacade;
        private List<Pizza> pizzas;
        private OrderFacade orderFacade;
        private UserFacade userFacade;
        private readonly CreatePizzaOrder pizzaOrder;
        private decimal summedPrice;

        public OrderSummaryPage(CreatePizzaOrder order)
        {
            InitializeComponent();
            this.pizzaOrder = order;

            summedPrice = 0;

            mealFacade = new MealFacade();
            orderFacade = new OrderFacade();

            setCustomerData();
            setOrderItems();
        }

        private void setCustomerData()
        {
            whoLabel.Content += $" {CurrentUserContainer.s_currentUser.FirstName} {CurrentUserContainer.s_currentUser.LastName}";
            phoneLabel.Content += $" {CurrentUserContainer.s_currentUser.PhoneNumber}";
            streetLabel.Content = $"{CurrentUserContainer.s_currentUser.Street}";
            postCodeLabel.Content = $"{CurrentUserContainer.s_currentUser.PostCode}";
            cityLabel.Content = $"{CurrentUserContainer.s_currentUser.City}";
            notesTextBox.Text = $" {pizzaOrder.UserNotes}";
            
        }


        private void setOrderItems()
        {
            foreach (CreatePizzaOrder.Item item in pizzaOrder.Items)
            {
                Pizza pizza = mealFacade.GetPizzaById(item.PizzaId);
                PizzaCrust pizzaCrust;
                PizzaSize pizzaSize;

                if (item.PizzaCrustId == 1) pizzaCrust = PizzaCrust.Thin();
                else pizzaCrust = PizzaCrust.Thick();

                if (item.PizzaSizeId == 1) pizzaSize = PizzaSize.Small();
                else if(item.PizzaSizeId == 2) pizzaSize = PizzaSize.Medium();
                else pizzaSize = PizzaSize.Large();

                TreeViewItem root = new TreeViewItem() { Header = $"{pizza.Name}" };
                summedPrice += pizza.BasePrice;

                root.Items.Add(new TreeViewItem() { Header = $"Rodzaj Ciasta: {pizzaCrust.Name} ({pizzaCrust.BasePrice}zł)" });
                root.Items.Add(new TreeViewItem() { Header = $"Rozmiar: {pizzaSize.Name} ({pizzaSize.BasePrice}zł)" });

                summedPrice += pizzaCrust.BasePrice;
                summedPrice += pizzaSize.BasePrice;

                TreeViewItem toppingsNode = new TreeViewItem() { Header = "Składniki" };

                foreach (PizzaTopping topping in pizza.PizzaToppings)
                {
                    toppingsNode.Items.Add(new TreeViewItem() { Header = $"{topping.Topping.Name} {topping.Topping.BasePrice}zł" });
                    summedPrice += topping.Topping.BasePrice;
                }

                if (item.ExtraToppingsIds != null)
                {
                    foreach (long toppingId in item.ExtraToppingsIds)
                    {
                        Topping topping = mealFacade.GetToppingById(toppingId);
                        toppingsNode.Items.Add(new TreeViewItem() { Header = $"{topping.Name} ({topping.BasePrice}zł)" });
                        summedPrice += topping.BasePrice;
                    }
                }

                root.Items.Add(toppingsNode);

                orderItemsTreeView.Items.Add(root);
            }
            summaryLabel.Content += $" {summedPrice}";
        }


        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void FinalOrderButton_Click(object sender, RoutedEventArgs e)
        {
            orderFacade.CreateOrder(pizzaOrder);
            System.Windows.Forms.MessageBox.Show("Zamówienie złożono pomyślnie.");
            NavigationService.Navigate(new MainMenuPage());
        }
    }
}
