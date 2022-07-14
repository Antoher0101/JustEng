using System.Linq;
using JustEng.JustEngDAL.Entities;
using JustEng.JustEngInterfaces;
using JustEng.ViewModels.Base;

namespace JustEng.ViewModels
{
	public class LibraryPageViewModel : BaseViewModel
	{
		private readonly IRepository<Library> _libraryRepository;

		private Library[] _libraries;

		public Library[] Libraries { get => _libraries; set => Set(ref _libraries, value); }

		public LibraryPageViewModel(IRepository<Library> LibrariesRepository)
		{
			_libraryRepository = LibrariesRepository;

			Libraries = _libraryRepository.Items.ToArray();
		}
	}
}
