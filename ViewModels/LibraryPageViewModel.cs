using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using JustEng.Infrastructure.Commands;
using JustEng.JustEngDAL.Entities;
using JustEng.JustEngInterfaces;
using JustEng.Services.Navigation;
using JustEng.Services.Stores;
using JustEng.ViewModels.Base;

namespace JustEng.ViewModels
{
	public class LibraryPageViewModel : ViewModelBase
	{
		private readonly IRepository<Library> _libraryRepository;

		private Library[] _libraries;
		public Library[] Libraries { get => _libraries; set => Set(ref _libraries, value); }

		#region commands

		#region Command OpenLibraryCommand - Open choosen library

		public ICommand OpenLibraryCommand { get; }

		#endregion

		#endregion

		public LibraryPageViewModel(IRepository<Library> LibrariesRepository, NavigationService<FlashcardPageViewModel> navService, LibraryStore libStore)
		{
			_libraryRepository = LibrariesRepository;

			OpenLibraryCommand = new OpenLibraryCommand(this, libStore, navService);

			Libraries = _libraryRepository.Items.ToArray();
		}
	}
}
