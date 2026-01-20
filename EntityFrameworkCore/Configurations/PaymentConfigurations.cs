using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubscriptionManagementSystem.Domain;
using System.Reflection.Emit;

namespace SubscriptionManagementSystem.EntityFrameworkCore.Configurations
{
    public class PaymentConfigurations : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {

            builder.Property(p => p.UserSubscriptionId)
                   .HasColumnName("User_Subscription_Id")
                   .IsRequired();

            builder.Property(p => p.Amount)
                   .IsRequired();

            builder.Property(p => p.PaidAt)
                   .HasColumnName("Paid_At")
                   .IsRequired(false);

            builder.Property(p => p.PaymentMethod)
                   .HasColumnName("Payment_Method")
                   .HasConversion<long>()
                   .IsRequired(false);
            builder
                .HasOne(p => p.UserSubscription)
                .WithOne(us => us.Payment)
                .HasForeignKey<Payment>(p => p.UserSubscriptionId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
