using System.Windows;
using MahApps.Metro.Controls;
using PizzeriaServer.Exceptions;
using PizzeriaServer.Service;

namespace PizzeriaProjekt
{
    public partial class loginWindow :MetroWindow
    {
        UserService userService = new UserService();
        public loginWindow()
        {
            InitializeComponent();
            TitleBarHeight = 23;
 
        }
     
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            {
                try
                {
                    if (userService.LogIn(loginBox.Text, passwordBox.ToString()))
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
                catch (System.NullReferenceException)
                {
                    System.Windows.MessageBox.Show("Niewprowadzono danych, wprowadź dane logowania");
                }

                catch (UserNotFoundException)
                {
                    System.Windows.MessageBox.Show("Niepoprawny login");
                }
                catch (MySqlConnector.MySqlException)
                {
                    System.Windows.MessageBox.Show("Błąd połączenia, spróbuj ponownie później");
                }



            }
        }
        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    passwordshowedBox.Text = passwordBox.Password;
                    passwordBox.Visibility = Visibility.Collapsed;
                    passwordshowedBox.Visibility = Visibility.Visible;
                }
                else
                {
                    passwordBox.Password = passwordshowedBox.Text;
                    passwordshowedBox.Visibility = Visibility.Collapsed;
                    passwordBox.Visibility = Visibility.Visible;
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
