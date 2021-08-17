using Guilherme.LojaVirtualApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Guilherme.LojaVirtualApi.Repository.Map
{
    public static class UserMap
    {
        public static void ConfigureUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users")
                  .HasKey(t => t.Id);
            modelBuilder.Entity<User>().Property(u => u.Id).UseIdentityColumn().HasColumnName("id").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Username).HasColumnName("username").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).HasColumnName("password").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.RefreshToken).HasColumnName("refreshToken");
            modelBuilder.Entity<User>().Property(u => u.RefreshTokenExpireTime).HasColumnName("refreshTokenExpireTime");
        }
    }
}
