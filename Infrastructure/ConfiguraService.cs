using Domain.Interfaces;
using Infrastructure.Data.DatabaseContext;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfiguraService
{
	public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
	{

		services.AddDbContext<AppDbContext>(option => option.UseLazyLoadingProxies().UseSqlServer(configuration["ConnectionStrings:Default"]), ServiceLifetime.Scoped);
		services.AddScoped<IBlogRepository, BlogRepository>();
		return services;
	}
}
