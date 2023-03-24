using ParkingApplication.Domain.Entities;
using ParkingMVC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMVC.Application.Interfaces
{
    public interface IParkingSpaceService
    {
        Task<IEnumerable<ParkingSpaceDTO>> GetParkingsSpaces();

        Task<ParkingSpaceDTO> GetParkingSpaceById(int? id);

        Task<ParkingSpaceDTO> GetCarParkingSpace(int? id);

        Task Add(ParkingSpaceDTO parkingDTO);

        Task Update(ParkingSpaceDTO parkingDTO);

        Task Remove(int id);
    }
}
