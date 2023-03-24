using ParkingMVC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMVC.Application.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarDTO>> GetCars();

        Task<CarDTO> GetCarById(int? id);

        Task Add(CarDTO carDTO);

        Task Update(CarDTO carDTO);

        Task Remove(int id);
    }
}
