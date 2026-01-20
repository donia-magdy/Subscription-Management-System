using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubscriptionManagementSystem.Domain;
using System.Reflection.Emit;

namespace SubscriptionManagementSystem.EntityFrameworkCore.Configurations
{
    public class UserSubscriptionConfigurations : IEntityTypeConfiguration<UserSubscription>
    {
        public void Configure(EntityTypeBuilder<UserSubscription> builder)
        {
            builder.ToTable("User_Subscriptions");


            builder.Property(us => us.UserId)
                   .HasColumnName("User_Id")
                   .IsRequired();

            builder.Property(us => us.SubscriptionId)
                   .HasColumnName("Subscription_Id")
                   .IsRequired();

            builder.Property(us => us.StartDate)
                   .HasColumnName("Start_Date")
                   .IsRequired();

            builder.Property(us => us.EndDate)
                   .HasColumnName("End_Date")
                   .IsRequired(false);

            builder.Property(us => us.IsActive)
                   .HasColumnName("Is_Active")
                   .IsRequired();

            builder
               .HasOne(us => us.Subscription)
               .WithMany(s => s.UserSubscriptions)
               .HasForeignKey(us => us.SubscriptionId);
            builder
                .HasOne(us => us.User)
                .WithMany(u => u.UserSubscriptions)
                .HasForeignKey(us => us.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
