using AutoMapper;
using ParkingApplication.Domain.Entities;
using ParkingMVC.Application.DTOs;

namespace ParkingMVC.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Car, CarDTO>().ReverseMap();
            CreateMap<ParkingSpace, ParkingSpaceDTO>().ReverseMap();
        }
    }
}
