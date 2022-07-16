using JustEng.Infrastructure.Commands;
using JustEng.Services.Navigation;
using JustEng.ViewModels.Base;

using System.Windows.Input;

namespace JustEng.ViewModels
{
	public class HomePageViewModel : ViewModelBase
	{
		public ICommand OpenTensePageCommand { get; }
		public ICommand OpenLibraryPageCommand { get; }

		public HomePageViewModel(NavigationService<TensePageViewModel> tenseNav, NavigationService<LibraryPageViewModel> libraryPage)
		{
			OpenTensePageCommand = new NavigateCommand(tenseNav);
			OpenLibraryPageCommand = new NavigateCommand(libraryPage);
		}
	}
}
