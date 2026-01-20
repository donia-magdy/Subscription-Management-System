using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubscriptionManagementSystem.Domain;

namespace SubscriptionManagementSystem.EntityFrameworkCore.Configurations
{
    public class SubscriptionConfigurations : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {


            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.Price)
                   .IsRequired();

            builder.Property(s => s.Cycle)
                   .HasConversion<long>()
                   .IsRequired();

            builder.Property(s => s.IsActive)
                   .HasColumnName("Is_active")
                   .IsRequired();
        }
    }
}
