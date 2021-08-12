using Guilherme.LojaVirtualApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Guilherme.LojaVirtualApi.Repository.Map
{
    public static class OrderMap
    {
        public static void ConfigureOrder(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("orders")
                  .HasKey(o => o.Id);
            modelBuilder.Entity<Order>().Property(o => o.Id).UseIdentityColumn().HasColumnName("id").IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.Date).HasColumnName("date").IsRequired();

            modelBuilder.Entity<Order>().HasOne(o => o.Payment).WithOne(p => p.Order).HasForeignKey<Payment>(p => p.OrderId);
        }
    }
}
