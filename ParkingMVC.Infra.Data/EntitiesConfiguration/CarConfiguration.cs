using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingApplication.Domain.Entities;

namespace ParkingApplication.Data.EntitiesConfiguration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Plate).HasMaxLength(6).IsRequired();
            builder.Property(p => p.Color).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Model).HasMaxLength(20).IsRequired();
            
        }
    }
}
