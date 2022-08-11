using JustEng.Infrastructure.Commands;
using JustEng.JustEngDAL.Entities;
using JustEng.JustEngInterfaces;
using JustEng.Services.Navigation;
using JustEng.Services.Stores;
using JustEng.ViewModels.Base;

using System;
using System.Linq;
using System.Windows.Input;

// todo: Rename a library using a context menu

namespace JustEng.ViewModels
{
	public class LibraryPageViewModel : ViewModelBase
	{
		private bool _showAddLibraryPopup;
		public bool ShowAddLibraryPopup { get => _showAddLibraryPopup; set => Set(ref _showAddLibraryPopup, value); }

		private string _newLibraryName = string.Empty;
		public string NewLibraryName { get => _newLibraryName; set => Set(ref _newLibraryName, value); }

		private readonly IRepository<Library> _libraryRepository;

		private Library[] _libraries;
		public Library[] Libraries { get => _libraries; set => Set(ref _libraries, value); }

		#region commands

		#region Command OpenLibraryCommand - Открыть выбранную библиотеку

		public ICommand OpenLibraryCommand { get; }

		#endregion
		#region Command AddNewLibraryCommand - Открыть попап добаление библиотеки

		private ICommand _AddNewLibraryCommand;

		public ICommand AddNewLibraryCommand => _AddNewLibraryCommand
			??= new RelayCommand(OnAddNewLibraryCommandExecuted, CanAddNewLibraryCommandExecute);

		/// <summary>Проверка возможности выполнения - Открыть попап добаление библиотеки</summary>
		private bool CanAddNewLibraryCommandExecute(object p) => true;

		/// <summary>Логика выполнения - Открыть попап добаление библиотеки</summary>
		private void OnAddNewLibraryCommandExecuted(object p)
		{
			ShowAddLibraryPopup = true;
		}

		#endregion
		#region Command CloseAddLibraryPopupCommand - Закрыть попап добавления библиотеки

		private ICommand _CloseAddLibraryPopupCommand;

		public ICommand CloseAddLibraryPopupCommand => _CloseAddLibraryPopupCommand
			??= new RelayCommand(OnCloseAddLibraryPopupCommandExecuted, CanCloseAddLibraryPopupCommandExecute);

		/// <summary>Проверка возможности выполнения - Закрыть попап добавления библиотеки</summary>
		private bool CanCloseAddLibraryPopupCommandExecute(object p) => true;

		/// <summary>Логика выполнения - Закрыть попап добавления библиотеки</summary>
		private void OnCloseAddLibraryPopupCommandExecuted(object p)
		{
			ShowAddLibraryPopup = false;
		}

		#endregion
		#region Command SaveNewLibraryCommand - Добавить новую библиотеку

		private ICommand _SaveNewLibraryCommand;

		public ICommand SaveNewLibraryCommand => _SaveNewLibraryCommand
			??= new RelayCommand(OnSaveNewLibraryCommandExecuted, CanSaveNewLibraryCommandExecute);

		/// <summary>Проверка возможности выполнения - Добавить новую библиотеку</summary>
		private bool CanSaveNewLibraryCommandExecute(object p)
		{
			return NewLibraryName != string.Empty;
		}

		/// <summary>Логика выполнения - Добавить новую библиотеку</summary>
		private void OnSaveNewLibraryCommandExecuted(object p)
		{
			if(NewLibraryName != string.Empty)
			{
				Console.WriteLine(NewLibraryName);
				SaveToDatabase();
			}
			NewLibraryName = string.Empty;
			CloseAddLibraryPopupCommand.Execute(p);
		}

		#endregion

		#endregion

		public LibraryPageViewModel(IRepository<Library> LibrariesRepository, NavigationService<FlashcardPageViewModel> navService, LibraryStore libStore)
		{
			_libraryRepository = LibrariesRepository;

			OpenLibraryCommand = new OpenLibraryCommand(this, libStore, navService);

			UpdateLibraryList();
		}

		private async void SaveToDatabase()
		{
			_libraryRepository.Add(new Library(){Name = NewLibraryName});
			UpdateLibraryList();
		}
		private void UpdateLibraryList() { Libraries = _libraryRepository.Items.ToArray(); }
	}
}
