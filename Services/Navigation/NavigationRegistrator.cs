using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JustEng.Services.Stores;
using JustEng.ViewModels;

using Microsoft.Extensions.DependencyInjection;

namespace JustEng.Services.Navigation
{
	static class NavigationRegistrator
	{
		public static IServiceCollection AddNavigations(this IServiceCollection services) => services
		   .AddSingleton<NavigationStore>()
		   .AddTransient<INavigationService, NavigationService<LibraryPageViewModel>>()
		   .AddTransient<NavigationService<LibraryPageViewModel>>()
		   .AddTransient<NavigationService<TensePageViewModel>>()
		   .AddTransient<NavigationService<FlashcardPageViewModel>>()
		   .AddTransient<NavigationService<HomePageViewModel>>()
		;
	}
}
