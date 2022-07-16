using JustEng.Services.Navigation;
using JustEng.ViewModels;

using Microsoft.Extensions.DependencyInjection;

namespace JustEng.Services
{
	static class ServicesRegistrator
	{
		public static IServiceCollection AddServices(this IServiceCollection services) => services
		   .AddNavigations()
		;
	}
}
