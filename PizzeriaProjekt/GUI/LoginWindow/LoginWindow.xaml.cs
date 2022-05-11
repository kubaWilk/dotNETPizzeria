using System.Windows;
using MahApps.Metro.Controls;
using PizzeriaProjekt.GUI.MainMenu;
using PizzeriaServer.Exceptions;
using PizzeriaServer.Service;
using PizzeriaServer.Users;

namespace PizzeriaProjekt
{
    public partial class loginWindow :MetroWindow
    {
        UserFacade userFacade = new UserFacade();
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
                    if (passwordVisibleBox.IsVisible) {
                        passwordBox.Password = passwordVisibleBox.Text;
                    }

                    if (userFacade.LogIn(loginBox.Text, passwordBox.Password))
                    {
                        System.Windows.MessageBox.Show($"Zapraszamy! ");
                        MainMenuWindow mainMenuWindow = new MainMenuWindow();
                        mainMenuWindow.Show();
                        this.Hide();
                        
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
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Wystąpił nieoczekiwany błąd");
                }

            }
        }
        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;

                if (toggleSwitch.IsOn == true)
                {
                    passwordVisibleBox.Text = passwordBox.Password;
                    passwordBox.Visibility = Visibility.Collapsed;
                    passwordVisibleBox.Visibility = Visibility.Visible;
            
                }
                else
                {
                    passwordBox.Password = passwordVisibleBox.Text;
                    passwordVisibleBox.Visibility = Visibility.Collapsed;
                    passwordBox.Visibility = Visibility.Visible;
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
