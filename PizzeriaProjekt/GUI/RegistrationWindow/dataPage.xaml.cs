
using PizzeriaServer.Exceptions;
using PizzeriaServer.Model;
using PizzeriaServer.Service;
using System.IO;
using System.Windows;
using System.Windows.Controls;
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
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            birthDateBox.DisplayDateStart = new DateTime(1900 - 01 - 01);
            birthDateBox.DisplayDateEnd = DateTime.Today;
            
        }
            private void goBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                User user = new User()
                {
                    Login = LoginBox.Text,
                    Password = passwordBox.Password,
                    FirstName = nameBox.Text,
                    LastName = surnameBox.Text,
                    Birthday = (DateTime)birthDateBox.SelectedDate,
                    PhoneNumber = phoneNumberBox.Text,
                    Street = streetBox.Text,
                    City = cityBox.Text,
                    PostCode = postCodeBox.Text,
                };
                Userservice.Register(user);
                var myWindow = Window.GetWindow(this);
                myWindow.Close();
                System.Windows.MessageBox.Show("Rejestracja przebiegła pomyślnie, możesz przejść do logowania Dziękujemy");
            }
            catch (InvalidOperationException)
            {

                wrongBirthDate.IsOpen = true;
            }
            catch (InvalidDataException ex)
            {
                if (ex.Message == "Wrong login format")
                {
                    
                    loginPopUp1.IsOpen = true; 
                    LoginBox.Clear();
                   

                }
                else if (ex.Message == "Wrong password format")
                {
                    wrongPassword.IsOpen = true;
                    passwordBox.Clear();
                }
                else if (ex.Message == "Wrong first name format")
                {
                   wrongName.IsOpen = true;
                    nameBox.Clear();
                }
                else if (ex.Message == "Wrong last name format")
                {
                    wrongSurname.IsOpen = true;
                    surnameBox.Clear();
                }
                else if (ex.Message == "Wrong phone number format")
                {
                    wrongPhone.IsOpen = true;
                    phoneNumberBox.Clear();
                }
                else if (ex.Message == "Wrong street format")
                {
                    wrongStreet.IsOpen = true;
                    streetBox.Clear();
                }
                else if (ex.Message == "Wrong city format")
                {
                    wrongCity.IsOpen = true;
                    cityBox.Clear();
                }
                else if (ex.Message == "Wrong post code format")
                {
                    wrongPostCode.IsOpen = true;  
                    postCodeBox.Clear();
                }
               
            }
            catch (MySqlConnector.MySqlException)
            {
                System.Windows.MessageBox.Show("Błąd połączenia, spróbuj ponownie później");
            }

            catch (UserAlreadyExistsException)
            {
             loginOccupied.IsOpen = true;
                LoginBox.Clear();
            }


            if (passwordBox.Password != checkPasswordBox.Password)
            {
                
                checkPasswordBox.Clear();
                passwordNoMatch.IsOpen = true;
            }


        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            loginWindow loginWindow = new loginWindow();
            loginWindow.Show();
            App.Current.MainWindow.Close();
        }

        private void LoginBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (loginPopUp1.IsOpen == true)
            {
                loginPopUp1.IsOpen = false;
            }
            else
                return;
            
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (wrongPassword.IsOpen == true)
            {
                wrongPassword.IsOpen = false;
            }
            else
                return;
        }

        private void checkPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (passwordNoMatch.IsOpen == true)
            {
                passwordNoMatch.IsOpen = false;
            }
            else
                return;
            
        }

        private void nameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (wrongName.IsOpen== true)
            {
                wrongName.IsOpen = false;
            }
            else
                return ;
        }

        private void birthDateBox_CalendarOpened(object sender, RoutedEventArgs e)
        {
            if (wrongBirthDate.IsOpen == true)
            {
                wrongBirthDate.IsOpen = false;
            }
            else
                return;
        }

        private void streetBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(wrongStreet.IsOpen == true)
            {
                wrongStreet.IsOpen = false;
            }
            else
                return;

        }

        private void surnameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (wrongSurname.IsOpen == true)
            {
                wrongSurname.IsOpen = false;
            }
            else return;
        }

        private void phoneNumberBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (wrongPhone.IsOpen == true)
            {
                wrongPhone.IsOpen = false;
            }
            else return ;
        }

        private void postCodeBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (wrongPostCode.IsOpen == true)
            {
                wrongPostCode.IsOpen = false;
            }
            else return;
        }

        private void cityBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (wrongCity.IsOpen == true)
            {
                wrongCity.IsOpen = false;
            }
            else return;
        }
    }
}
