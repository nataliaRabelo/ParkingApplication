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
    public class ParkingSpaceService : IParkingSpaceService
    {
        private IParkingSpaceRepository _parkingRepository;

        private readonly IMapper _mapper;

        public ParkingSpaceService(IParkingSpaceRepository parkingRepository, IMapper mapper)
        {
            _parkingRepository = parkingRepository;
                throw new ArgumentNullException(nameof(parkingRepository));
            _mapper = mapper;
        }

        public async Task<ParkingSpaceDTO> GetCarParkingSpace(int? id)
        {
            var parkingEntity = await _parkingRepository.GetCarParkingSpace(id);
            return _mapper.Map<ParkingSpaceDTO>(parkingEntity);
        }

        public async Task<ParkingSpaceDTO> GetParkingSpaceById(int? id)
        {
            var parkingEntity = await _parkingRepository.GetParkingSpace(id);
            return _mapper.Map<ParkingSpaceDTO>(parkingEntity);
        }

        public async Task<IEnumerable<ParkingSpaceDTO>> GetParkingsSpaces()
        {
            var parkingEntity = await _parkingRepository.GetParkingSpaces();
            return _mapper.Map<IEnumerable<ParkingSpaceDTO>>(parkingEntity);
        }
        public async Task Add(ParkingSpaceDTO parkingDTO)
        {
            var parkingEntity = _mapper.Map<ParkingSpace>(parkingDTO);
            await _parkingRepository.Create(parkingEntity);
        }

        public async Task Remove(int id)
        {
            var parkingEntity = _parkingRepository.GetParkingSpace(id).Result;
            await _parkingRepository.Remove(parkingEntity);
        }

        public async Task Update(ParkingSpaceDTO parkingDTO)
        {
            var parkingEntity = _mapper.Map<ParkingSpace>(parkingDTO);
            await _parkingRepository.Update(parkingEntity);
        }
    }
}
