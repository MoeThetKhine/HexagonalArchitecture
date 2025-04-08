using HexagonalArchitecture.DbService.AppDbContextModels;
using HexagonalArchitecture.Domain.Features.Blog;
using HexagonalArchitecture.Infrastructure.Features.Blog;
using Microsoft.EntityFrameworkCore;

namespace HexagonalArchitecture.API.Extension;

public static class DependencyInjection
{
	private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
	{
		builder.Services.AddDbContext<AppDbContext>(
			opt =>
			{
				opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
				opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
			},
			ServiceLifetime.Transient,
			ServiceLifetime.Transient
			);
		return services;
	}

	private static IServiceCollection AddRepositoryServices(this  IServiceCollection services)
	{
		return services.AddScoped<IBlogPort,BlogAdapter>();
	}

	public static IServiceCollection AddDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
	{
		services.AddDbContextService(builder)
				.AddRepositoryServices();

		return services;
	} 
}
