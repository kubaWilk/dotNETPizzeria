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
    /// Interaction logic for welcomePage.xaml
    /// </summary>
    public partial class welcomePage : Page
    {
        public welcomePage()
        {
            InitializeComponent();
        }

        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }

        private void ProceedButton__Click(object sender, RoutedEventArgs e)
        {
            rulesPage rulesPage = new rulesPage();
            NavigationService.Navigate(rulesPage);
        }
    }
}
