using ParkingApplication.Domain.Entities;

namespace ParkingApplication.Domain.Interfaces
{
    public interface IParkingSpaceRepository
    {
        Task<IEnumerable<ParkingSpace>> GetParkingSpaces();

        Task<ParkingSpace> GetParkingSpace(int? id);

        Task<ParkingSpace> Create(ParkingSpace parkingSpace);

        Task<ParkingSpace> Update(ParkingSpace parkingSpace);

        Task<ParkingSpace> Remove(ParkingSpace parkingSpace);
    }
}

