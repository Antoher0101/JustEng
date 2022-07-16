using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using JustEng.Infrastructure.Commands;
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

		#region commands

		#region Command OpenLibraryCommand - Open choosen library

		private ICommand _OpenLibraryCommand;

		public ICommand OpenLibraryCommand => _OpenLibraryCommand
			??= new RelayCommand(OnOpenLibraryCommandExecuted, CanOpenLibraryCommandExecute);

		/// <summary>Проверка возможности выполнения - Open choosen library</summary>
		private bool CanOpenLibraryCommandExecute(object p) => true;

		/// <summary>Логика выполнения - Open choosen library</summary>
		private void OnOpenLibraryCommandExecuted(object p)
		{
			
		}

		#endregion

		#endregion

		public LibraryPageViewModel(IRepository<Library> LibrariesRepository)
		{
			_libraryRepository = LibrariesRepository;

			Libraries = _libraryRepository.Items.ToArray();
		}
	}
}
