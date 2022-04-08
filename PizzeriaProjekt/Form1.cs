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
            List<Pizza> pizzas = mealsFacade.GetPizzas();
            pizzas.ForEach(pizza =>
            {
                string entry = $"{pizza.Name}\t{pizza.ActualPrice}zł";
                this.pizzaBox.Items.Add(entry);
            });
        }
    }
}