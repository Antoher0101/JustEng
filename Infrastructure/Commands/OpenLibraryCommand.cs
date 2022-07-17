using JustEng.Infrastructure.Commands.Base;
using JustEng.Services.Navigation;
using JustEng.Services.Stores;
using JustEng.ViewModels;

namespace JustEng.Infrastructure.Commands
{
	public class OpenLibraryCommand : CommandBase
	{
		private readonly LibraryPageViewModel _viewModel;
		private readonly LibraryStore _libraryStore;
		private readonly INavigationService _navigationService;

		public OpenLibraryCommand(LibraryPageViewModel viewModel, LibraryStore libraryStore, INavigationService navigationService)
		{
			_viewModel = viewModel;
			_libraryStore = libraryStore;
			_navigationService = navigationService;
		}

		public override bool CanExecute(object parameter) => true;

		public override void Execute(object parameter)
		{
			var index = (int)parameter;
			_libraryStore.CurrentLibrary = _viewModel.Libraries[index];
			_navigationService.Navigate();
		}
	}
}
