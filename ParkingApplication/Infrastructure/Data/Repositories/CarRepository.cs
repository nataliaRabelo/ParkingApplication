using Microsoft.EntityFrameworkCore;
using ParkingApplication.Data.Context;
using ParkingApplication.Domain.Entities;
using ParkingApplication.Domain.Interfaces;

namespace ParkingApplication.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        ApplicationDbContext _carContext;

        public CarRepository(ApplicationDbContext context)
        {
            _carContext = context;
        }
        public async Task<Car> Create(Car car)
        {
            _carContext.Add(car);
            await _carContext.SaveChangesAsync();
            return car;
        }

        public async Task<Car> GetCar(int? id)
        {
            return await _carContext.Cars.FindAsync(id);
        }

        public async Task<IEnumerable<Car>> GetCars()
        {
            return await _carContext.Cars.ToListAsync();
        }

        public async Task<Car> Remove(Car car)
        {
            _carContext.Remove(car);
            await _carContext.SaveChangesAsync();
            return car;
        }

        public async Task<Car> Update(Car car)
        {
            _carContext.Update(car);
            await _carContext.SaveChangesAsync();
            return car;
        }
    }
}
