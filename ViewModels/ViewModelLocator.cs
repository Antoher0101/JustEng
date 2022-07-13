using Microsoft.Extensions.DependencyInjection;

namespace JustEng.ViewModels
{
	class ViewModelLocator
	{
		public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
	}
}
