using Guilherme.LojaVirtualApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Guilherme.LojaVirtualApi.Repository.Map
{
    public static class PaymentMap
    {
        public static void ConfigurePayment(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>().ToTable("payments")
                  .HasKey(p => p.Id);
            modelBuilder.Entity<Payment>().Property(p => p.Id).UseIdentityColumn().HasColumnName("id").IsRequired();
            modelBuilder.Entity<Payment>().Property(p => p.PaymentStatus).HasColumnName("paymentStatus").IsRequired();
            modelBuilder.Entity<PaymentWithBillet>().Property(p => p.DueDate).HasColumnName("dueDate").IsRequired();
            modelBuilder.Entity<PaymentWithBillet>().Property(p => p.PayDate).HasColumnName("payDate");
            modelBuilder.Entity<PaymentWithCard>().Property(p => p.Installments).HasColumnName("installments").IsRequired();
        }
    }
}
