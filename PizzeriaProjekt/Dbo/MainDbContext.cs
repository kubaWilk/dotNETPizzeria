using Microsoft.EntityFrameworkCore;
using PizzeriaProjekt.Model;
using PizzeriaProjekt.Meals;

namespace PizzeriaProjekt.Dbo
{
    internal class MainDbContext : DbContext
    {
        public const string DATABASE_HOST = "DOTNETPIZZERIA_DATABASE_HOST";
        public const string DATABASE_PORT = "DOTNETPIZZERIA_DATABASE_PORT";
        public const string DATABASE_NAME = "DOTNETPIZZERIA_DATABASE_NAME";
        public const string DATABASE_USER = "DOTNETPIZZERIA_DATABASE_USER";
        public const string DATABASE_PASSWORD = "DOTNETPIZZERIA_DATABASE_PASSWORD";

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>()
                .ToTable("Meals")
                .HasDiscriminator<Category>("Category")
                .HasValue<Pizza>(Category.PIZZA);

            modelBuilder.Entity<Topping>().ToTable("Toppings");

            modelBuilder.Entity<PizzaTopping>()
                .ToTable("PizzaToppings")
                .HasKey(pt => new { pt.MealId, pt.ToppingId });
            modelBuilder.Entity<PizzaTopping>()
                .HasOne(pt => pt.Pizza)
                .WithMany(p => p.PizzaToppings)
                .HasForeignKey(pt => pt.MealId);
            modelBuilder.Entity<PizzaTopping>()
                .HasOne(pt => pt.Topping)
                .WithMany(t => t.PizzaToppings)
                .HasForeignKey(pt => pt.ToppingId);

            // seeding
            var pizzas = new[]
            {
                new Pizza{Id = 1, Name = "Margherita", BasePrice = 20.00m},
                new Pizza{Id = 2, Name = "Capricciosa", BasePrice = 23.00m},
                new Pizza{Id = 3, Name = "Japanelo", BasePrice = 23.00m},
                new Pizza{Id = 4, Name = "Hawaii", BasePrice = 24.00m},
            };

            var toppings = new[]
            {
                new Topping{Id = 1, Name = "Mozzarella", BasePrice = 2.00m},
                new Topping{Id = 2, Name = "Ham", BasePrice = 2.00m},
                new Topping{Id = 3, Name = "Japanelo", BasePrice = 2.00m},
                new Topping{Id = 4, Name = "Pepperoni", BasePrice = 2.00m},
                new Topping{Id = 5, Name = "Pineapple", BasePrice = 2.00m},
            };

            //var pizzaToppings = new[]
            //{
            //    new PizzaTopping{MealId = pizzas[0].Id, ToppingId = toppings[0].Id, Pizza = pizzas[0], Topping = toppings[0]},

            //    new PizzaTopping{MealId = pizzas[1].Id, ToppingId = toppings[0].Id, Pizza = pizzas[1], Topping = toppings[0]},
            //    new PizzaTopping{MealId = pizzas[1].Id, ToppingId = toppings[1].Id, Pizza = pizzas[1], Topping = toppings[1]},

            //    new PizzaTopping{MealId = pizzas[2].Id, ToppingId = toppings[0].Id, Pizza = pizzas[2], Topping = toppings[0]},
            //    new PizzaTopping{MealId = pizzas[2].Id, ToppingId = toppings[3].Id, Pizza = pizzas[2], Topping = toppings[3]},
            //    new PizzaTopping{MealId = pizzas[2].Id, ToppingId = toppings[4].Id, Pizza = pizzas[2], Topping = toppings[4]},

            //    new PizzaTopping{MealId = pizzas[3].Id, ToppingId = toppings[0].Id, Pizza = pizzas[3], Topping = toppings[0]},
            //    new PizzaTopping{MealId = pizzas[3].Id, ToppingId = toppings[2].Id, Pizza = pizzas[3], Topping = toppings[2]},
            //    new PizzaTopping{MealId = pizzas[3].Id, ToppingId = toppings[4].Id, Pizza = pizzas[3], Topping = toppings[4]},
            //};
            var pizzaToppings = new[]
            {
                new PizzaTopping{MealId = pizzas[0].Id, ToppingId = toppings[0].Id},
                
                new PizzaTopping{MealId = pizzas[1].Id, ToppingId = toppings[0].Id},
                new PizzaTopping{MealId = pizzas[1].Id, ToppingId = toppings[1].Id},
                
                new PizzaTopping{MealId = pizzas[2].Id, ToppingId = toppings[0].Id},
                new PizzaTopping{MealId = pizzas[2].Id, ToppingId = toppings[3].Id},
                new PizzaTopping{MealId = pizzas[2].Id, ToppingId = toppings[4].Id},

                new PizzaTopping{MealId = pizzas[3].Id, ToppingId = toppings[0].Id},
                new PizzaTopping{MealId = pizzas[3].Id, ToppingId = toppings[2].Id},
                new PizzaTopping{MealId = pizzas[3].Id, ToppingId = toppings[4].Id}
            };

            modelBuilder.Entity<Pizza>().HasData(pizzas);
            modelBuilder.Entity<Topping>().HasData(toppings);
            modelBuilder.Entity<PizzaTopping>().HasData(pizzaToppings);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = prepareConnectionString();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        private string prepareConnectionString()
        {
            string? databaseHost = Environment.GetEnvironmentVariable(DATABASE_HOST);
            string? databasePort = Environment.GetEnvironmentVariable(DATABASE_PORT);
            string? databaseName = Environment.GetEnvironmentVariable(DATABASE_NAME);
            string? databaseUser = Environment.GetEnvironmentVariable(DATABASE_USER);
            string? databasePassword = Environment.GetEnvironmentVariable(DATABASE_PASSWORD);

            if (databaseHost == null
                || databasePort == null
                || databaseName == null
                || databaseUser == null
                || databasePassword == null)
            {
                const string ERROR_MESSAGE = $"Could not setup database connection. " +
                    $"You must specify environment variables: " +
                    $"{DATABASE_HOST}, {DATABASE_PORT}, {DATABASE_NAME}, " +
                    $"{DATABASE_USER}, {DATABASE_PASSWORD}";

                throw new ArgumentNullException(ERROR_MESSAGE);
            }

            var connectionString = $"Server={databaseHost};" +
                $"Port={databasePort};" +
                $"Database={databaseName};" +
                $"Uid={databaseUser};" +
                $"Pwd={databasePassword};";

            return connectionString;
        }
    }
}
