using AutoMapper;
using ParkingApplication.Domain.Entities;
using ParkingApplication.Domain.Interfaces;
using ParkingMVC.Application.DTOs;
using ParkingMVC.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMVC.Application.Services
{
    public class CarService : ICarService
    {
        private ICarRepository _carRepository;
        
        private readonly IMapper _mapper;
        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository= carRepository;
            _mapper= mapper;
        }

        public async Task<IEnumerable<CarDTO>> GetCars()
        {
            var carsEntity = await _carRepository.GetCars();
            return _mapper.Map<IEnumerable<CarDTO>>(carsEntity);
        }

        public async Task<CarDTO> GetCarById(int? id)
        {
            var carEntity = await _carRepository.GetCar(id);
            return _mapper.Map<CarDTO>(carEntity);
        }

        public async Task Add(CarDTO carDTO)
        {
            var carEntity = _mapper.Map<Car>(carDTO);
            await _carRepository.Create(carEntity);
        }

        public async Task Remove(int id)
        {
            var carEntity = _carRepository.GetCar(id).Result;
            await _carRepository.Remove(carEntity);
        }

        public async Task Update(CarDTO carDTO)
        {
            var carEntity = _mapper.Map<Car>(carDTO);
            await _carRepository.Update(carEntity);
        }
    }
}
