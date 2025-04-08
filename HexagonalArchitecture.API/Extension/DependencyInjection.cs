namespace HexagonalArchitecture.API.Extension;

public static class DependencyInjection
{

	#region AddDbContextService

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

	#endregion

	#region AddRepositoryServices

	private static IServiceCollection AddRepositoryServices(this  IServiceCollection services)
	{
		return services.AddScoped<IBlogPort,BlogAdapter>();
	}

	#endregion

	#region AddDependencyInjection

	public static IServiceCollection AddDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
	{
		services.AddDbContextService(builder)
				.AddRepositoryServices();

		return services;
	}

	#endregion

}
