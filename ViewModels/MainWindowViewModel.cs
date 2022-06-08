using JustEng.Infrastructure.Commands;
using JustEng.Models.Tenses;
using JustEng.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace JustEng.ViewModels
{
	internal class MainWindowViewModel : BaseViewModel
	{
		private Page _MainPage;
		private Page _TensePage;
		private Page _FlashcardPage;


		#region Properties

		private Page _currentPage;
		public Page CurrentPage
		{
			get => _currentPage;
			set => Set(ref _currentPage, value);
		}

		#endregion

		#region Command defenitions
		public ICommand AnyCommand { get; }
		private bool CanAnyCommandExecute(object p) => true;
		private void OnAnyCommandExecuted(object p)
		{
			// Command logic
		}
		public ICommand OpenMainPageCommand { get; }
		private bool CanOpenMainPageCommandExecute(object p) => true;
		private void OnOpenMainPageCommandExecuted(object p)
		{
			CurrentPage = _MainPage;
		}
		public ICommand OpenTensePageCommand { get; }
		private bool CanOpenTensePageCommandExecute(object p) => true;
		private void OnOpenTensePageCommandExecuted(object p)
		{
			CurrentPage = _TensePage;

		}
		public ICommand OpenFlashcardPageCommand { get; }
		private bool CanOpenFlashcardPageCommandExecute(object p) => true;
		private void OnOpenFlashcardPageCommandExecuted(object p)
		{
			CurrentPage = _FlashcardPage;
		}
		#endregion
		public MainWindowViewModel()
		{
			#region Init commands
			AnyCommand = new RelayCommand(OnAnyCommandExecuted, CanAnyCommandExecute);
			OpenMainPageCommand = new RelayCommand(OnOpenMainPageCommandExecuted, CanOpenMainPageCommandExecute);
			OpenTensePageCommand = new RelayCommand(OnOpenTensePageCommandExecuted, CanOpenTensePageCommandExecute);
			OpenFlashcardPageCommand = new RelayCommand(OnOpenFlashcardPageCommandExecuted, CanOpenFlashcardPageCommandExecute);
			#endregion

			#region Init Pages
			_MainPage = new Pages.MainPage() { DataContext = this };
			_TensePage = new Pages.TensePage();
			_FlashcardPage = new Pages.FlashcardPage();
			CurrentPage = _MainPage;
			#endregion
		}
	}
}
