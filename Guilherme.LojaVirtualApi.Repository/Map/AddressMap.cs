using Guilherme.LojaVirtualApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Guilherme.LojaVirtualApi.Repository.Map
{
    public static class AddressMap
    {
        public static void ConfigureAddress(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().ToTable("addresses")
                  .HasKey(a => a.Id);

            modelBuilder.Entity<Address>().Property(a => a.Id).UseIdentityColumn().HasColumnName("id").IsRequired();
            modelBuilder.Entity<Address>().Property(a => a.Street).HasColumnName("street").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Address>().Property(a => a.Number).HasColumnName("number").IsRequired();
            modelBuilder.Entity<Address>().Property(a => a.Complement).HasColumnName("complement");
            modelBuilder.Entity<Address>().Property(a => a.Block).HasColumnName("block");
            modelBuilder.Entity<Address>().Property(a => a.ZipCode).HasColumnName("zipCode");

            modelBuilder.Entity<Address>().HasOne(a => a.Customer).WithMany(c => c.Addresses).HasForeignKey(a => a.CustomerId);
        }
    }
}
