using Microsoft.EntityFrameworkCore;
using PizzeriaServer.Meals.Dal;
using PizzeriaServer.Meals.Models;
using PizzeriaServer.Model;
using PizzeriaServer.Orders.Dal;
using PizzeriaServer.Orders.Models;
using PizzeriaServer.Users.Dal;

namespace PizzeriaServer.Dbo
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
        public DbSet<OrderLine> OrderLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MealDbConfiguration());
            modelBuilder.ApplyConfiguration(new ToppingDbConfiguration());
            modelBuilder.ApplyConfiguration(new PizzaToppingDbConfiguration());
            modelBuilder.ApplyConfiguration(new UserDbConfiguration());
            modelBuilder.ApplyConfiguration(new OrderLineDbConfiguration());

            UserDbInitializer.SeedUser(modelBuilder);
            MealDbInitializer.SeedPizza(modelBuilder);

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