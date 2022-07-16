using Microsoft.Extensions.DependencyInjection;

namespace JustEng.ViewModels
{
	static class ViewModelRegistrator
	{
		public static IServiceCollection AddViewModels(this IServiceCollection services) => services
		   .AddScoped<MainWindowViewModel>()
		   .AddScoped<TensePageViewModel>()
		   .AddScoped<LibraryPageViewModel>()
		   .AddScoped<FlashcardPageViewModel>()
		;
	}
}
