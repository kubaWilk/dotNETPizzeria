using Microsoft.EntityFrameworkCore;
using PizzeriaProjekt.Model;
using PizzeriaProjekt.Meals;
using PizzeriaProjekt.Meals.Model;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Topping> Toppings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>().ToTable("Meals");

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

            modelBuilder.Entity<PizzaCrust>()
                .ToTable("PizzaCrusts")
                .Property(pc => pc.Name)
                .HasConversion(new EnumToStringConverter<PizzaCrust.CrustType>());

            modelBuilder.Entity<PizzaSize>()
                .ToTable("PizzaSizes")
                .Property(ps => ps.Name)
                .HasConversion(new EnumToStringConverter<PizzaSize.SizeType>());

            SeedPizza(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void SeedPizza(ModelBuilder modelBuilder)
        {
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

            var pizzaCrusts = new[]
            {
                new PizzaCrust{Id = 1, Name = PizzaCrust.CrustType.THIN, BasePrice = 0.0m},
                new PizzaCrust{Id = 2, Name = PizzaCrust.CrustType.THICK, BasePrice = 2.0m}
            };

            var pizzaSizes = new[]
            {
                new PizzaSize{Id = 1, Name = PizzaSize.SizeType.SMALL, DiameterCentimeters = (int)PizzaSize.SizeType.SMALL, BasePrice = 0.0m },
                new PizzaSize{Id = 2, Name = PizzaSize.SizeType.MEDIUM, DiameterCentimeters = (int)PizzaSize.SizeType.MEDIUM, BasePrice = 8.0m },
                new PizzaSize{Id = 3, Name = PizzaSize.SizeType.LARGE, DiameterCentimeters = (int)PizzaSize.SizeType.LARGE, BasePrice = 18.0m }
            };

            modelBuilder.Entity<Pizza>().HasData(pizzas);
            modelBuilder.Entity<Topping>().HasData(toppings);
            modelBuilder.Entity<PizzaTopping>().HasData(pizzaToppings);
            modelBuilder.Entity<PizzaCrust>().HasData(pizzaCrusts);
            modelBuilder.Entity<PizzaSize>().HasData(pizzaSizes);
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
