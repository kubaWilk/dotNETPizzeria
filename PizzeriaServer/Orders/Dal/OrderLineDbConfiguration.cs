using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzeriaServer.Meals.Models;
using PizzeriaServer.Orders.Models;

namespace PizzeriaServer.Orders.Dal
{
    internal class OrderDbConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.Property("CreatedAt").HasDefaultValueSql("current_timestamp()");
            builder.Property("IsDone").HasDefaultValue(false);
            //builder.OwnsMany(o => o.OrderLines);
        }
    }

    internal class PizzaOrderLineDbConfiguration : IEntityTypeConfiguration<PizzaOrderLine>
    {
        public void Configure(EntityTypeBuilder<PizzaOrderLine> builder)
        {
            builder.ToTable("OrderLines");
            builder.Property("CrustId").HasDefaultValue(1);
            builder.Property("SizeId").HasDefaultValue(1);
        }
    }
}
