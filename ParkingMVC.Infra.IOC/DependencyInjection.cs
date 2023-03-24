using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkingApplication.Data.Context;
using ParkingApplication.Data.Repositories;
using ParkingApplication.Domain.Interfaces;
using ParkingMVC.Application.Interfaces;
using ParkingMVC.Application.Mappings;
using ParkingMVC.Application.Services;

namespace ParkingMVC.Infra.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IParkingSpaceRepository, ParkingSpaceRepository>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IParkingSpaceService, ParkingSpaceService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}