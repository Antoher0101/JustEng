using JustEng.Infrastructure.Commands;
using JustEng.ViewModels.Base;
using JustEng.Views.Pages;

using System.Windows.Controls;
using System.Windows.Input;

namespace JustEng.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
		private Page _MainPage;
		private Page _TensePage;
		private Page _FlashcardPage;
		private Page _LibraryPage;


		#region Properties

		private Page _currentPage;
		public Page CurrentPage
		{
			get => _currentPage;
			set => Set(ref _currentPage, value);
		}

		#endregion

		#region Command defenitions

		private ICommand _AnyCommand;
		public ICommand AnyCommand => _AnyCommand
			??= new RelayCommand(OnAnyCommandExecuted, CanAnyCommandExecute);
		private bool CanAnyCommandExecute(object p) => true;
		private void OnAnyCommandExecuted(object p)
		{
			// Command logic
		}
		
		private ICommand _OpenMainPageCommand;
		public ICommand OpenMainPageCommand => _OpenMainPageCommand
			  ??= new RelayCommand(OnOpenMainPageCommandExecuted, CanOpenMainPageCommandExecute);

		private bool CanOpenMainPageCommandExecute(object p) => true;
		private void OnOpenMainPageCommandExecuted(object p)
		{
			CurrentPage = _MainPage;
		}

		private ICommand _OpenTensePageCommand;
		public ICommand OpenTensePageCommand => _OpenTensePageCommand 
			??= new RelayCommand(OnOpenTensePageCommandExecuted, CanOpenTensePageCommandExecute);
		private bool CanOpenTensePageCommandExecute(object p) => true;
		private void OnOpenTensePageCommandExecuted(object p)
		{
			CurrentPage = _TensePage ??= new TensePage();

		}
		private ICommand _OpenFlashcardPageCommand;
		public ICommand OpenFlashcardPageCommand => _OpenFlashcardPageCommand
			  ??= new RelayCommand(OnOpenFlashcardPageCommandExecuted, CanOpenFlashcardPageCommandExecute);

		private bool CanOpenFlashcardPageCommandExecute(object p) => true;
		private void OnOpenFlashcardPageCommandExecuted(object p)
		{
			CurrentPage = _LibraryPage ??= new LibraryPage();
		}
		#endregion

		
		public MainWindowViewModel()
		{
			#region Init Pages
			_MainPage = new MainPage() { DataContext = this };
			CurrentPage = _MainPage;
			#endregion
		}
	}
}
