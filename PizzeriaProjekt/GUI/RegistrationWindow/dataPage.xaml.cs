using PizzeriaProjekt.Meals;
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

namespace PizzeriaProjekt
{
    /// <summary>
    /// Interaction logic for dataPage.xaml
    /// </summary>
    public partial class dataPage : Page
    {


        MealFacade meals = new MealFacade();
        public dataPage()
        {
            InitializeComponent();
        }

        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {

            var myWindow = Window.GetWindow(this);
            myWindow.Close();
            System.Windows.MessageBox.Show( "Rejestracja przebiegła pomyślnie, możesz przejść do logowania", "Dziękujemy");


        }
    }
}
