using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
            builder.HasOne(order => order.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
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
