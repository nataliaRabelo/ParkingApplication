using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingApplication.Domain.Entities;

namespace ParkingApplication.Data.EntitiesConfiguration
{
    public class ParkingSpaceConfiguration : IEntityTypeConfiguration<ParkingSpace>
    {
        public void Configure(EntityTypeBuilder<ParkingSpace> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }
}
