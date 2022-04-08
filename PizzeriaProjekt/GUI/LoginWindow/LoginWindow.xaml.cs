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
using MahApps.Metro.Controls;
using PizzeriaProjekt.Service;
using PizzeriaProjekt.Exceptions;
using PizzeriaProjekt;
namespace PizzeriaProjekt
{
    public partial class loginWindow :MetroWindow
    {
        UserService userService = new UserService();
        public loginWindow()
        {
            InitializeComponent();
            TitleBarHeight = 20;
        }
     
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            {
                try
                {
                    if (userService.LogIn(loginBox.Text, passwordBox.Text))
                    {
                        System.Windows.MessageBox.Show($"Zapraszamy! ");
                        Form MainMenu = new Form();
                        MainMenu.ShowDialog();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Nieprawidłowe hasło");
                        passwordBox.Clear();
                    }

                }
                catch (UserNotFoundException)
                {
                    System.Windows.MessageBox.Show("Niepoprawny login");
                }
                catch (MySqlConnector.MySqlException)
                {
                    System.Windows.MessageBox.Show("Błąd połączenia, spróbuj ponownie później");
                }
                catch (System.NullReferenceException)
                {
                    System.Windows.MessageBox.Show("Niewprowadzono danych, wprowadź dane logowania");
                }

            }
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            registerWindow register = new registerWindow();
            register.ShowDialog();
            
       
        }
    }


}
    
    
    
    
    
    
    
