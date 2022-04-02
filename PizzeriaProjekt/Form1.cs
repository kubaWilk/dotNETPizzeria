using PizzeriaProjekt.Exceptions;
using PizzeriaProjekt.Service;
using System.Windows.Forms;
namespace PizzeriaProjekt
{
    
        
        public partial class Form1 : Form
        {

        UserService userService = new UserService();  
        public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
               
            }
            private void button1_Click(object sender, EventArgs e)
            {
             try
            {
                if (userService.LogIn("test" ,"test")) {//zmieniæ na odniesienie do DB!
                    MessageBox.Show($"Zapraszamy! {CurrentUserContainer.currentUser.Id} {CurrentUserContainer.currentUser.Login} {CurrentUserContainer.currentUser.Password} ");
                }
                else
                {
                    MessageBox.Show("Nieprawid³owe has³o");
                    passwordBox.Clear();
                }
                
            }
            catch (UserNotFoundException)
            {
                MessageBox.Show("Niepoprawny login");
            }
            catch (MySqlConnector.MySqlException)
            {
                MessageBox.Show("B³¹d po³¹czenia, spróbuj ponownie póŸniej");
            }

        }
        }

    
}