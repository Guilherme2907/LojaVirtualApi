using Guilherme.LojaVirtualApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Guilherme.LojaVirtualApi.Repository.Map
{
    public static class TelephoneMap
    {
        public static void ConfigureTelephone(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Telephone>().ToTable("telephones")
                  .HasKey(t => t.Id);
            modelBuilder.Entity<Telephone>().Property(t => t.Id).UseIdentityColumn().HasColumnName("id").IsRequired();
            modelBuilder.Entity<Telephone>().Property(t => t.Number).HasColumnName("number").IsRequired();

        }
    }
}
