using Guilherme.LojaVirtualApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Guilherme.LojaVirtualApi.Repository.Map
{
    public static class CustomerMap
    {
        public static void ConfigureCustomer(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("customers")
                  .HasKey(c => c.Id);
            modelBuilder.Entity<Customer>().Property(c => c.Id).UseIdentityColumn().HasColumnName("id").IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.Name).HasColumnName("name").IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.Email).HasColumnName("email").IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.Cpf).HasColumnName("cpf");
            modelBuilder.Entity<Customer>().Property(c => c.Cnpj).HasColumnName("cnpj");

            modelBuilder.Entity<Customer>().HasMany(c => c.Addresses).WithOne(a => a.Customer).HasForeignKey(a => a.CustomerId);
            modelBuilder.Entity<Customer>().HasMany(c => c.Orders).WithOne(o => o.Customer).HasForeignKey(o => o.CustomerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
