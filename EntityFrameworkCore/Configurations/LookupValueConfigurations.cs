using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubscriptionManagementSystem.Domain;

namespace SubscriptionManagementSystem.EntityFrameworkCore.Configurations
{
    public class LookupValueConfigurations : IEntityTypeConfiguration<LookupValue>
    {
        public void Configure(EntityTypeBuilder<LookupValue> builder)
        {
            builder.ToTable("Lookup_Values");
            builder.Property(lv => lv.Code)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(lv => lv.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(lv => lv.LookupTypeId)
                   .HasColumnName("Lookup_Type_Id")
                   .IsRequired();
            builder
               .HasOne(lv => lv.LookupType)
               .WithMany(lt => lt.LookupValues)
               .HasForeignKey(lv => lv.LookupTypeId)
               .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
