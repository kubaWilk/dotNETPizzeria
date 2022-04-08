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
using System.Windows.Shapes;
using System.Windows.Navigation;
using MahApps.Metro.Controls;
namespace PizzeriaProjekt
{

    public partial class registerWindow : MetroWindow
    {
      
        public registerWindow()
        {
            InitializeComponent();

        }
      
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RulesFrame.Content = new welcomePage();

            TitleBarHeight = 20;
            WindowTitleBrush = new SolidColorBrush(Colors.White);
        }

        private void finishRegister_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            loginWindow loginWindow = new loginWindow();
            loginWindow.Show();
        }
    }
}

