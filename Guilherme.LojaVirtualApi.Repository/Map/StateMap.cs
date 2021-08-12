using Guilherme.LojaVirtualApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Guilherme.LojaVirtualApi.Repository.Map
{
    public static class StateMap
    {
        public static void ConfigureState(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>().ToTable("states")
                  .HasKey(s => s.Id);
            modelBuilder.Entity<State>().Property(s => s.Id).UseIdentityColumn().HasColumnName("id").IsRequired();
            modelBuilder.Entity<State>().Property(s => s.Name).HasColumnName("name").HasMaxLength(50).IsRequired();

            modelBuilder.Entity<State>().HasMany(s => s.Cities).WithOne(c => c.State).HasForeignKey(c => c.StateId);
        }
    }
}
