using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubscriptionManagementSystem.Domain;
using System.Reflection.Emit;

namespace SubscriptionManagementSystem.EntityFrameworkCore.Configurations
{
    public class LookupTypeConfigurations : IEntityTypeConfiguration<LookupType>
    {
        public void Configure(EntityTypeBuilder<LookupType> builder)
        {
            builder.ToTable("Lookup_Types");


            builder.Property(lt => lt.Code)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(lt => lt.Name)
                   .IsRequired()
                   .HasMaxLength(50);
           
        }
    }
}
