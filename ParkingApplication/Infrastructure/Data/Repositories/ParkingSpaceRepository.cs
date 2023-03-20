using Microsoft.EntityFrameworkCore;
using ParkingApplication.Data.Context;
using ParkingApplication.Domain.Entities;
using ParkingApplication.Domain.Interfaces;

namespace ParkingApplication.Data.Repositories
{
    public class ParkingSpaceRepository : IParkingSpaceRepository
    {
        ApplicationDbContext _parkingContext;

        public ParkingSpaceRepository(ApplicationDbContext context)
        {
            _parkingContext = context;
        }
        public async Task<ParkingSpace> Create(ParkingSpace parkingSpace)
        {
            _parkingContext.Add(parkingSpace);
            await _parkingContext.SaveChangesAsync();
            return parkingSpace;
        }

        public async Task<ParkingSpace> GetCarParkingSpace(int? id)
        {
            return await _parkingContext.ParkingSpaces.Include(c => c.Car)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ParkingSpace> GetParkingSpace(int? id)
        {
            return await _parkingContext.ParkingSpaces.FindAsync(id);
        }

        public async Task<IEnumerable<ParkingSpace>> GetParkingSpaces()
        {
            return await _parkingContext.ParkingSpaces.ToListAsync();
        }

        public async Task<ParkingSpace> Remove(ParkingSpace parkingSpace)
        {
            _parkingContext.Remove(parkingSpace);
            await _parkingContext.SaveChangesAsync();
            return parkingSpace;
        }

        public async Task<ParkingSpace> Update(ParkingSpace parkingSpace)
        {
            _parkingContext.Update(parkingSpace);
            await _parkingContext.SaveChangesAsync();
            return parkingSpace;
        }
    }
}
