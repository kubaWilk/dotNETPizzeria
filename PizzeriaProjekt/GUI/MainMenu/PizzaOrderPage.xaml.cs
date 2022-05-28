using PizzeriaServer;
using PizzeriaServer.Meals;
using PizzeriaServer.Meals.Models;
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

namespace PizzeriaProjekt.GUI.MainMenu
{
    /// <summary>
    /// Interaction logic for PizzaOrderPage.xaml
    /// </summary>
    public partial class PizzaOrderPage : Page
    {
        private MealFacade mealFacade;
        private List<Pizza> pizzas;
        private CreatePizzaOrder order;
        private OrderFacade orderFacade;

        public PizzaOrderPage()
        {
            InitializeComponent();
            toppingsLabel.Content = string.Empty;

            order = new CreatePizzaOrder();
            order.Items = new List<CreatePizzaOrder.Item>();   //brak inicjalizacji w konstruktorze w CreatePizzaOrder więc trzeba ręcznie zainicjalizować
            mealFacade = new MealFacade();
            orderFacade = new OrderFacade();

            getPizzas();

            order.UserId = CurrentUserContainer.s_currentUser.Id;
            thinRadioButton.IsChecked = true;
            smallRadioButton.IsChecked = true;
        }

        private void getPizzas()
        {
            pizzas = mealFacade.GetPizzas();

            foreach (Pizza pizza in pizzas)
            {
                PizzasList.Items.Add($"{pizza.Name}");
            }
        }

        private void PizzasList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pizza pizza = pizzas.Find(x => x.Name.Equals(PizzasList.SelectedItem));

            if (pizza == null) return;

            string content = string.Empty;

            foreach (PizzaTopping topping in pizza.PizzaToppings)
            {
                content += $"{topping.Topping.Name}, ";
            }

            toppingsLabel.Content = content.Remove(content.Length - 2);   //tylko po to, żeby wywalić przecinek z końca dodatków
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            cartListBox.Items.Add(PizzasList.SelectedItem);

            CreatePizzaOrder.Item item = new CreatePizzaOrder.Item();

            Pizza pizza = pizzas.Find(x => x.Name.Equals(PizzasList.SelectedItem));
            item.PizzaId = pizza.Id;

            if (thiccRadioButton.IsChecked == true)
            {
                item.PizzaCrustId = 2;
            }
            else
            {
                item.PizzaCrustId = 1;
            }

            if (smallRadioButton.IsChecked == true)
            {
                item.PizzaSizeId = 1;
            }
            else if (mediumRadioButton.IsChecked == true)
            {
                item.PizzaSizeId = 2;
            }
            else
            {
                item.PizzaSizeId = 3;
            }

            order.Items.Add(item);
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (cartListBox.SelectedItem == null) return;

            order.Items.Remove(order.Items[cartListBox.SelectedIndex]);
            cartListBox.Items.Remove(cartListBox.SelectedItem);
        }

        private void orderButton_Click(object sender, RoutedEventArgs e)
        {
            order.UserNotes = commentsTextBox.Text;
            OrderSummaryPage orderSummaryPage= new OrderSummaryPage(order);
            NavigationService.Navigate(orderSummaryPage);

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
