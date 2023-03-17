using ParkingApplication.Domain.Entities;

namespace ParkingApplication.Domain.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetCars();

        Task<Car> GetCar(int? id);

        Task<Car> Create(Car car);

        Task<Car> Update(Car car);

        Task<Car> Remove(Car car);
    }
}
