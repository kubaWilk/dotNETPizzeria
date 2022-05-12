using PizzeriaServer.Meals;
using PizzeriaServer.Meals.Models;
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
        public PizzaOrderPage()
        {
            InitializeComponent();
            mealFacade = new MealFacade();
            List<Pizza> pizzas = mealFacade.GetPizzas();
            foreach (Pizza pizza in pizzas)
            {
                PizzasList.Items.Add($"{pizza.Name}");
            }
        }


        private void PizzasList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            TestLabel.Content = PizzasList.SelectedItem.ToString();
            


        }

        private void goBackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void OrderUserDetailsBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
