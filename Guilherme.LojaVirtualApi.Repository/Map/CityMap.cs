using Guilherme.LojaVirtualApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Guilherme.LojaVirtualApi.Repository.Map
{
    public static class CityMap
    {
        public static void ConfigureCity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().ToTable("cities")
                  .HasKey(c => c.Id);
            modelBuilder.Entity<City>().Property(c => c.Id).UseIdentityColumn().HasColumnName("id").IsRequired();
            modelBuilder.Entity<City>().Property(c => c.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
        }
    }
}
