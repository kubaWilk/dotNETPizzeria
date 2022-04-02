using PizzeriaProjekt.Exceptions;
using PizzeriaProjekt.Service;
using System.Windows.Forms;
using PizzeriaProjekt;
namespace PizzeriaProjekt
{
    
        
        public partial class LoginForm : Form
        {

        UserService userService = new UserService();  
        public LoginForm()
            {
                InitializeComponent();
                
            }
            private void Form1_Load(object sender, EventArgs e)
            {
               
            }
            private void loginButton_Click(object sender, EventArgs e)
            {
             try
            {
                if (userService.LogIn(loginBox.Text, passwordBox.Text)) {
                    MessageBox.Show($"Zapraszamy! {CurrentUserContainer.currentUser.Id} {CurrentUserContainer.currentUser.Login} {CurrentUserContainer.currentUser.Password} ");
                    Form MainMenu = new Form();
                    MainMenu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nieprawid�owe has�o");
                    passwordBox.Clear();
                }
                
            }
            catch (UserNotFoundException)
            {
                MessageBox.Show("Niepoprawny login");
            }
            catch (MySqlConnector.MySqlException)
            {
                MessageBox.Show("B��d po��czenia, spr�buj ponownie p�niej");
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Niewprowadzono danych, wprowad� dane logowania");
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            LoginForm loginForm = new LoginForm();
            registerForm.Show();
            loginForm.Close();
            
        }
    }

    
}