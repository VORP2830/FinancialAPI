using Financial.Application.DTOs.Mapping;
using Financial.Application.Interfaces;
using Financial.Application.Services;
using Financial.Domain.Interfaces;
using Financial.Infra.Data.Context;
using Financial.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("DATABASE") ?? configuration.GetConnectionString("DefaultConnection");
            service.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            service.AddAutoMapper(typeof(MappingProfile));

            service.AddScoped<IUnitOfWork, UnitOfWork>();

            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IMovementService, MovementService>();
            service.AddScoped<ITokenService, TokenService>();

            return service;
        }
    }
}