using PizzeriaServer.Meals;
using System.Windows.Forms;
namespace PizzeriaProjekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Login";
            textBox2.Text = "Has�o";
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

            if (textBox2.Text == "Has�o")
            {
                textBox2.Clear();
            }
            else
                return;
        }

        MealFacade mealsFacade = new MealFacade();
        private void button1_Click(object sender, EventArgs e)
        {
            string pic = "../../../margarita.jpg";
            ShowMyImage(pic, 20, 20);
            
            List<Pizza> pizzas = mealsFacade.GetPizzas();
            pizzas.ForEach(pizza =>
            {
                string entry = $"{pizza.Name}\t{pizza.ActualPrice}zł";
                this.pizzaBox.Items.Add(entry);
            });
        }

        private void ShowMyImage(string fileToDisplay, int xSize, int ySize)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = Image.FromFile(fileToDisplay);
            //pictureBox2.ClientSize = new Size(xSize, ySize);
            //pictureBox2.Image = new Bitmap(fileToDisplay); ;
        }
    }
    
}