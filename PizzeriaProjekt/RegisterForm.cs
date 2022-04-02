using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzeriaProjekt
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

        }

        private void rulesLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            rulesPanel.Show();
            rulesBox.AutoCheck = true;
        }




        private void RegisterForm_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = File.ReadAllText(@"Rules.txt");
            rulesBox.AutoCheck = false;
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
        
            if (rulesBox.AutoCheck== true)
            {
                rulesPanel.Hide();
            }
            else
            {
                MessageBox.Show("Zapoznaj się z regulaminem aby przejśc dalej");
            }
                
        }


        private void rulesBox_Click(object sender, EventArgs e)
        {

            if (rulesBox.AutoCheck == false)
            {

                MessageBox.Show("Zapoznaj się z regulaminem");
                rulesBox.AutoCheck = false;
               

            }
           else  if (richTextBox1.GetPositionFromCharIndex(0).Y != -977)
            {
                rulesBox.Checked = false;
                MessageBox.Show("Należy przeczytać cały regulamin!");
            }
            else if (rulesBox.AutoCheck == true)
            {
                rulesBox.AutoCheck = true;
            
            }
        
        }
    }
}
  
