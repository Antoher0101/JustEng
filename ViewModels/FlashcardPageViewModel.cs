using JustEng.Infrastructure;
using JustEng.Infrastructure.Commands;
using JustEng.JustEngDAL;
using JustEng.JustEngDAL.Entities;
using JustEng.JustEngInterfaces;
using JustEng.Services.Navigation;
using JustEng.Services.Stores;
using JustEng.ViewModels.Base;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

// todo: Анимация перелистывания карточек

namespace JustEng.ViewModels
{
	public class FlashcardPageViewModel : ViewModelBase
	{
		#region Popups

		private bool _showEditPopup;
		public bool ShowEditPopup { get => _showEditPopup; set => Set(ref _showEditPopup, value); }

		private bool _showApplyPopup;
		public bool ShowApplyPopup { get => _showApplyPopup; set => Set(ref _showApplyPopup, value); }

		private bool _showClosePopup;
		public bool ShowClosePopup { get => _showClosePopup; set => Set(ref _showClosePopup, value); }

		#region Command OpenEditPopupCommand - Открыть главный попап редактирования

		private ICommand _OpenEditPopupCommand;

		public ICommand OpenEditPopupCommand => _OpenEditPopupCommand
			??= new RelayCommand(OnOpenEditPopupCommandExecuted, CanOpenEditPopupCommandExecute);

		/// <summary>Проверка возможности выполнения - Открыть главный попап редактирования</summary>
		private bool CanOpenEditPopupCommandExecute(object p) => true;

		/// <summary>Логика выполнения - Открыть главный попап редактирования</summary>
		private void OnOpenEditPopupCommandExecuted(object p)
		{
			ShowEditPopup = true;
		}

		#endregion
		#region Command CloseEditPopupCommand - Закрыть главный попап редактирования(ОЧИСТКА ИЗМЕНЕНИЙ)

		private ICommand _CloseEditPopupCommand;

		public ICommand CloseEditPopupCommand => _CloseEditPopupCommand
			??= new RelayCommand(OnCloseEditPopupCommandExecuted, CanCloseEditPopupCommandExecute);

		/// <summary>Проверка возможности выполнения - Закрыть главный попап редактирования</summary>
		private bool CanCloseEditPopupCommandExecute(object p) => true;

		/// <summary>Логика выполнения - Закрыть главный попап редактирования</summary>
		private void OnCloseEditPopupCommandExecuted(object p)
		{
			ShowEditPopup = false;
			NewFlashcardsStorage.Clear();
		}

		#endregion

		#region Command OpenApplyPopupCommand - Открыть попап подтверждения редактирования

		private ICommand _OpenApplyPopupCommand;

		public ICommand OpenApplyPopupCommand => _OpenApplyPopupCommand
			??= new RelayCommand(OnOpenApplyPopupCommandExecuted, CanOpenApplyPopupCommandExecute);

		/// <summary>Проверка возможности выполнения - Открыть главный попап редактирования</summary>
		private bool CanOpenApplyPopupCommandExecute(object p)
		{
			return NewFlashcardsStorage.Count > 0;
		}

		/// <summary>Логика выполнения - Открыть главный попап редактирования</summary>
		private void OnOpenApplyPopupCommandExecuted(object p)
		{
			ShowApplyPopup = true;
		}

		#endregion
		#region Command CloseApplyPopupCommand - Закрыть попап подтверждения редактирования

		private ICommand _CloseApplyPopupCommand;

		public ICommand CloseApplyPopupCommand => _CloseApplyPopupCommand
			??= new RelayCommand(OnCloseApplyPopupCommandExecuted, CanCloseApplyPopupCommandExecute);

		/// <summary>Проверка возможности выполнения - Закрыть главный попап редактирования</summary>
		private bool CanCloseApplyPopupCommandExecute(object p) => true;

		/// <summary>Логика выполнения - Закрыть главный попап редактирования</summary>
		private void OnCloseApplyPopupCommandExecuted(object p)
		{
			ShowApplyPopup = false;
		}

		#endregion

		#region Command OpenClosePopupCommand - Закрыть попап выхода без сохранения

		private ICommand _OpenClosePopupCommand;

		public ICommand OpenClosePopupCommand => _OpenClosePopupCommand
			??= new RelayCommand(OnOpenClosePopupCommandExecuted, CanOpenClosePopupCommandExecute);

		/// <summary>Проверка возможности выполнения - Закрыть попап выхода без сохранения</summary>
		private bool CanOpenClosePopupCommandExecute(object p) => true;

		/// <summary>Логика выполнения - Закрыть попап выхода без сохранения</summary>
		private void OnOpenClosePopupCommandExecuted(object p)
		{
			if (NewFlashcardsStorage.Count == 0)
			{
				CloseAllPopupsCommand.Execute(this);
				return;
			}
			ShowClosePopup = true;
		}

		#endregion
		#region Command CloseClosePopupCommand - Закрыть попап выхода без сохранения

		private ICommand _CloseClosePopupCommand;

		public ICommand CloseClosePopupCommand => _CloseClosePopupCommand
			??= new RelayCommand(OnCloseClosePopupCommandExecuted, CanCloseClosePopupCommandExecute);

		/// <summary>Проверка возможности выполнения - Закрыть попап выхода без сохранения</summary>
		private bool CanCloseClosePopupCommandExecute(object p) => true;

		/// <summary>Логика выполнения - Закрыть попап выхода без сохранения</summary>
		private void OnCloseClosePopupCommandExecuted(object p)
		{
			ShowClosePopup = false;
		}

		#endregion

		#region Command CloseAllPopupsCommand - Закрыть все попапы

		private ICommand _CloseAllPopupsCommand;

		public ICommand CloseAllPopupsCommand => _CloseAllPopupsCommand
			??= new RelayCommand(OnCloseAllPopupsCommandExecuted, CanCloseAllPopupsCommandExecute);

		/// <summary>Проверка возможности выполнения - Закрыть все попапы</summary>
		private bool CanCloseAllPopupsCommandExecute(object p) => true;

		/// <summary>Логика выполнения - Закрыть все попапы</summary>
		private void OnCloseAllPopupsCommandExecuted(object p)
		{
			ShowClosePopup = false;
			ShowApplyPopup = false;
			CloseEditPopupCommand.Execute(this);
		}

		#endregion

		#endregion

		private readonly LibraryStore _libStore;
		public Library CurrentLibrary => _libStore.CurrentLibrary;

		private IRepository<Flashcard> _flashcardRepository { get; set; }
		private bool _switchedSides;

		#region Notifable properties

		private List<Flashcard> _Flashcards;
		public List<Flashcard> Flashcards
		{
			get => _Flashcards;
			set => Set(ref _Flashcards, value);
		}

		/// <summary>
		/// Array contains recently added flashcards that haven't yet been saved in the database
		/// </summary>
		public ObservableCollection<Flashcard> NewFlashcardsStorage { get; set; } = new();

		private Flashcard _currentFlashcard;
		public Flashcard CurrentFlashcard
		{
			get
			{
				if (_switchedSides)
				{
					var viewCard = new Flashcard() { Face = _currentFlashcard.Back, Back = _currentFlashcard.Face };
					return viewCard;
				}
				return _currentFlashcard;
			}
			set => Set(ref _currentFlashcard, value);
		}

		private int _currentFlashcardNumber;
		/// <summary>
		/// This value should always be one more then a actual flashcard index in the Flashcard[] array.
		/// </summary>
		public int CurrentFlashcardNumber
		{
			get => _currentFlashcardNumber;
			set
			{
				Set(ref _currentFlashcardNumber, value);
				OnCurrentFlashcardNumberChanged(in _currentFlashcardNumber);
			}
		}

		private int _totalFlashcards;
		public int TotalFlashcards
		{
			get => _totalFlashcards;
			set => Set(ref _totalFlashcards, value);
		}

		#endregion

		#region Other Events
		private void OnCurrentFlashcardNumberChanged(in int value)
		{
			if (value <= 0 || value > TotalFlashcards)
			{
				CurrentFlashcard = null;
				return;
			}
			CurrentFlashcard = _Flashcards[value - 1];
		}

		private void OnCurrentLibraryChanged()
		{
			OnPropertyChanged(nameof(CurrentLibrary));
			InitLibrary();
		}
		#endregion

		#region commands

		#region Command NextFlashcardCommand - Следующая карточка

		private ICommand _NextFlashcardCommand;

		public ICommand NextFlashcardCommand => _NextFlashcardCommand
			??= new RelayCommand(OnNextFlashcardCommandExecuted, CanNextFlashcardCommandExecute);

		/// <summary>Проверка возможности выполнения - Следующая карточка</summary>
		private bool CanNextFlashcardCommandExecute(object p)
		{
			if (CurrentFlashcardNumber >= TotalFlashcards)
			{
				return false;
			}
			return true;
		}

		/// <summary>Логика выполнения - Следующая карточка</summary>
		private void OnNextFlashcardCommandExecuted(object p)
		{
			CurrentFlashcardNumber++;
		}

		#endregion

		#region Command PrevFlashcardCommand - Предыдущая карточка

		private ICommand _PrevFlashcardCommand;

		public ICommand PrevFlashcardCommand => _PrevFlashcardCommand
			??= new RelayCommand(OnPrevFlashcardCommandExecuted, CanPrevFlashcardCommandExecute);

		/// <summary>Проверка возможности выполнения - Предыдущая карточка</summary>
		private bool CanPrevFlashcardCommandExecute(object p)
		{
			if (CurrentFlashcardNumber <= 1)
			{
				return false;
			}
			return true;
		}

		/// <summary>Логика выполнения - Предыдущая карточка</summary>
		private void OnPrevFlashcardCommandExecuted(object p)
		{
			CurrentFlashcardNumber--;
		}

		#endregion

		#region Command ShuffleFlashcardsCommand - Перемешать карточки

		private ICommand _ShuffleFlashcardsCommand;

		public ICommand ShuffleFlashcardsCommand => _ShuffleFlashcardsCommand
			??= new RelayCommand(OnShuffleFlashcardsCommandExecuted, CanShuffleFlashcardsCommandExecute);

		/// <summary>Проверка возможности выполнения - Перемешать карточки</summary>
		private bool CanShuffleFlashcardsCommandExecute(object p) => true;

		/// <summary>Логика выполнения - Перемешать карточки</summary>
		private void OnShuffleFlashcardsCommandExecuted(object p)
		{
			if (TotalFlashcards == 0) return;
			var rand = new Random();
			Utils.Shuffle(Flashcards, rand);
			CurrentFlashcardNumber = 1;
		}

		#endregion

		#region Command OpenLibraryPageCommand - Открыть страницу выбора библиотеки
		public ICommand OpenLibraryPageCommand { get; }

		#endregion

		#region Command SwitchFlashcardSidesCommand - Поменять основную сторону карточек

		private ICommand _SwitchFlashcardSidesCommand;

		public ICommand SwitchFlashcardSidesCommand => _SwitchFlashcardSidesCommand
			??= new RelayCommand(OnSwitchFlashcardSidesCommandExecuted, CanSwitchFlashcardSidesCommandExecute);

		/// <summary>Проверка возможности выполнения - Поменять основную сторону карточек</summary>
		private bool CanSwitchFlashcardSidesCommandExecute(object p) => true;

		/// <summary>Логика выполнения - Поменять основную сторону карточек</summary>
		private void OnSwitchFlashcardSidesCommandExecuted(object p)
		{
			if (_switchedSides) _switchedSides = false;
			else _switchedSides = true;

		}

		#endregion

		#region Command AddNewFlashcardCommand - Добавить новую карточку

		private ICommand _AddNewFlashcardCommand;

		public ICommand AddNewFlashcardCommand => _AddNewFlashcardCommand
			??= new RelayCommand(OnAddNewFlashcardCommandExecuted, CanAddNewFlashcardCommandExecute);

		/// <summary>Проверка возможности выполнения - Добавить новую карточку</summary>
		private bool CanAddNewFlashcardCommandExecute(object p) => true;

		/// <summary>Логика выполнения - Добавить новую карточку</summary>
		private void OnAddNewFlashcardCommandExecuted(object p)
		{
			NewFlashcardsStorage.Add(new Flashcard());
		}

		#endregion

		#region Command SaveChangesCommand - Сохранение изменений
		private ICommand _SaveChangesCommand;

		public ICommand SaveChangesCommand => _SaveChangesCommand
			??= new RelayCommand(OnSaveChangesCommandExecuted, CanSaveChangesCommandExecute);

		/// <summary>Проверка возможности выполнения - Сохранение изменений</summary>
		private bool CanSaveChangesCommandExecute(object p) => true;

		/// <summary>Логика выполнения - Сохранение изменений</summary>
		private void OnSaveChangesCommandExecuted(object p)
		{
			SaveToDatabase();
			CloseApplyPopupCommand.Execute(this);
			NewFlashcardsStorage.Clear();
		}
		#endregion

		#region Command AnyCommand - Удаление карточки из базы данных

		private ICommand _DeleteFlashcardCommand;

		public ICommand DeleteFlashcardCommand => _DeleteFlashcardCommand
			??= new RelayCommand(OnAnyCommandExecuted, CanAnyCommandExecute);

		/// <summary>Проверка возможности выполнения - Удаление карточки из базы данных</summary>
		private bool CanAnyCommandExecute(object p) => true;

		/// <summary>Логика выполнения - Удаление карточки из базы данных</summary>
		private void OnAnyCommandExecuted(object p)
		{
			if (p is not null)
			{
				var item = ((ListBoxItem)p).Content as Flashcard;
				DeleteFromDatabase(item.Id);
			}
		}

		#endregion

		#region Command DeleteNewFlashcardCommand - Удаление карточки из временного хранилища

		private ICommand _DeleteNewFlashcardCommand;

		public ICommand DeleteNewFlashcardCommand => _DeleteNewFlashcardCommand
			??= new RelayCommand(OnDeleteNewFlashcardCommandExecuted, CanDeleteNewFlashcardCommandExecute);

		/// <summary>Проверка возможности выполнения - Удаление карточки из временного хранилища</summary>
		private bool CanDeleteNewFlashcardCommandExecute(object p) => true;

		/// <summary>Логика выполнения - Удаление карточки из временного хранилища</summary>
		private void OnDeleteNewFlashcardCommandExecuted(object p)
		{
			if (p is not null)
			{
				var item = ((ListBoxItem)p).Content as Flashcard;
				NewFlashcardsStorage.Remove(item);
			}
		}

		#endregion
		 
		#endregion

		public FlashcardPageViewModel(NavigationService<LibraryPageViewModel> libraryPage, IRepository<Flashcard> flashcardRepository, LibraryStore libStore)
		{
			_libStore = libStore;

			_flashcardRepository = flashcardRepository;
			InitLibrary();

			OpenLibraryPageCommand = new NavigateCommand(libraryPage);


			_libStore.CurrentLibraryChanged += OnCurrentLibraryChanged;
		}

		private void InitLibrary()
		{
			TotalFlashcards = 0;

			UpdateLibrary();

			if (TotalFlashcards > 0)
				CurrentFlashcardNumber = 1;
			else CurrentFlashcardNumber = 0;
		}

		private async void SaveToDatabase()
		{
			if (NewFlashcardsStorage.Count > 0)
			{
				var lib = _flashcardRepository as DbRepository<Flashcard>;
				lib.AutoSaveChanges = false;
				foreach (Flashcard flashcard in NewFlashcardsStorage)
				{
					flashcard.Library = CurrentLibrary;
					await lib.AddAsync(flashcard);
				}
				lib.SaveChangesAsync();
				lib.AutoSaveChanges = true;
			}
			UpdateLibrary();
		}

		private void UpdateLibrary()
		{
			Flashcards = _flashcardRepository.Items.Where(s => s.Library.Id == CurrentLibrary.Id).ToList();
			TotalFlashcards = Flashcards.Count;
		}
		private async void DeleteFromDatabase(int id)
		{
			var lib = _flashcardRepository as DbRepository<Flashcard>;
			await lib.DeleteAsync(id);
			UpdateLibrary();
		}
	}
}