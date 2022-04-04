using System;
using System.Collections.Generic;
using System.IO;
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
using Point = System.Windows.Point;

namespace PizzeriaProjekt
{


   


    public partial class rulesPage : Page
    {
        
      
        public rulesPage()
        {
            InitializeComponent();
        }
        private void Accepted_Click(object sender, RoutedEventArgs e)
        {
         dataPage data = new dataPage();
         this.NavigationService.Navigate(data);
           
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            testbox.Text = File.ReadAllText(@"Rules.txt");
        }

        private void noAccepted_Click(object sender, RoutedEventArgs e)
        {
          NavigationService.GoBack();
        }

    }
}
