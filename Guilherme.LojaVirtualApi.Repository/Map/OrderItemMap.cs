using Guilherme.LojaVirtualApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Guilherme.LojaVirtualApi.Repository.Map
{
    public static class OrderItemMap
    {
        public static void ConfigureOrderItem(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().ToTable("order-Items")
                 .HasKey(o => new { o.OrderId, o.ProductId });

            modelBuilder.Entity<OrderItem>().Property(o => o.OrderId).IsRequired().HasColumnName("orderId");
            modelBuilder.Entity<OrderItem>().Property(o => o.ProductId).IsRequired().HasColumnName("productId");
            modelBuilder.Entity<OrderItem>().Property(o => o.Quantity).IsRequired().HasColumnName("quantity");
            modelBuilder.Entity<OrderItem>().Property(o => o.Price).IsRequired().HasColumnName("price");
            modelBuilder.Entity<OrderItem>().Property(o => o.Discount).IsRequired().HasColumnName("discount");

            modelBuilder.Entity<OrderItem>().HasOne(o => o.Order).WithMany(c => c.Items).HasForeignKey(o => o.OrderId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderItem>().HasOne(o => o.Product).WithMany(c => c.Items).HasForeignKey(o => o.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
