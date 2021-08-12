using Guilherme.LojaVirtualApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Guilherme.LojaVirtualApi.Repository.Map
{
    public static class ProductMap
    {
        public static void ConfigureProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("products")
                  .HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Id).UseIdentityColumn().HasColumnName("id").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnName("price").IsRequired();

            //modelBuilder.Entity<Product>().HasMany(p => p.Categories).WithMany(c => c.Products).UsingEntity(e => e.ToTable("category-products"));
            //modelBuilder.Entity<Product>().HasMany(p => p.Items).WithOne(i => i.Product).HasForeignKey(i => i.ProductId);
        }
    }
}
