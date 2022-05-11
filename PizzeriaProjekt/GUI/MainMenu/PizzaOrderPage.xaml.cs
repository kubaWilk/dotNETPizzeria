using PizzeriaServer.Meals;
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
    }


        private void ToppingsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TestLabel.Content = ToppingsList.SelectedItem.ToString();
        }
    }
}
