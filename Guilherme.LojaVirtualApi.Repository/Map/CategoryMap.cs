using Guilherme.LojaVirtualApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Guilherme.LojaVirtualApi.Repository.Map
{
    public static class CategoryMap
    {
       public static void ConfigureCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("categories")
                .HasKey(c => c.Id);
            modelBuilder.Entity<Category>().Property(c => c.Id).UseIdentityColumn().HasColumnName("id").IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.Name).HasColumnName("name").HasMaxLength(50).IsRequired();

            modelBuilder.Entity<Category>().HasMany(a => a.Products).WithMany(p => p.Categories).UsingEntity(e => e.ToTable("category-products"));
        }
    }
}
