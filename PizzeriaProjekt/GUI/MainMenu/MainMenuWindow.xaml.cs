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

namespace PizzeriaProjekt.GUI.MainMenu
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        public MainMenuWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            System.Windows.Application.Current.Shutdown();
        }

        private void Frame_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MainMenuFrame_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainMenuFrame.Content = new MainMenuPage(this);
        }
    }
}
