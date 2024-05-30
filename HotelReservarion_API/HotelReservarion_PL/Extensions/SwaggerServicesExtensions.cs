namespace HotelReservarion_PL.Extensions
{
	public static class SwaggerServicesExtensions
	{
		public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
		{
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();
			return services;
		}

		public static WebApplication UseSwagger_1(this WebApplication webApplication)
		{
			webApplication.UseSwagger();
			webApplication.UseSwaggerUI();
			return webApplication;
		}
	}
}
