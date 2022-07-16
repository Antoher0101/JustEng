using Microsoft.Extensions.DependencyInjection;

namespace JustEng.ViewModels
{
	class ViewModelLocator
	{
		public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
		public HomePageViewModel HomeWindowModel => App.Services.GetRequiredService<HomePageViewModel>();
		public TensePageViewModel TensePageModel => App.Services.GetRequiredService<TensePageViewModel>();
		public LibraryPageViewModel LibraryModel => App.Services.GetRequiredService<LibraryPageViewModel>();
		public FlashcardPageViewModel FlashcardPageModel => App.Services.GetRequiredService<FlashcardPageViewModel>();
	}
}
