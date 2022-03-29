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
            textBox2.PasswordChar = '*';
            textBox1.MaxLength = 32;

            }
            private void Form1_Load(object sender, EventArgs e)
            {
                textBox1.Text = "Login";
                textBox2.Text = "Has³o";
            }

            private void textBox1_Click(object sender, EventArgs e)
            {
                if (textBox1.Text == "Login")
                {
                    textBox1.Clear();
                }
                else
                    return;
            }

            private void textBox2_Click(object sender, EventArgs e)
            {

                if (textBox2.Text == "Has³o") 
                {
                    textBox2.Clear();
                }
                else
                    return;
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
                    textBox2.Clear();
                }
                
            }
            catch (UserNotFoundException)
            {
                MessageBox.Show("Niepoprawny login");
            }
            }
        }

    
}