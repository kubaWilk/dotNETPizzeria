
using PizzeriaServer.Service;
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


namespace PizzeriaProjekt
{
    /// <summary>
    /// Interaction logic for dataPage.xaml
    /// </summary>
    public partial class dataPage : Page
    { 
        UserService Userservice= new UserService();
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

            /*  User user = new User()
            {
                 Login = "",
                 Password = "",
                 FirstName = "test",
                 LastName = "test",
                 Birthday = new DateTime(),   need to finish this
                 PhoneNumber = "",
                 Street = "",
                 City = "",
                 PostCode = ""
             };
           
            Userservice.Register(user);*/
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
            System.Windows.MessageBox.Show( "Rejestracja przebiegła pomyślnie, możesz przejść do logowania Dziękujemy");


        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            loginWindow loginWindow = new loginWindow();
            loginWindow.Show();
            App.Current.MainWindow.Close();
        }
    }
}
