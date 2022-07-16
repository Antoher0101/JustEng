using System;
using JustEng.Infrastructure.Commands;
using JustEng.ViewModels.Base;
using JustEng.Views.Pages;

using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;

namespace JustEng.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
		private BaseViewModel _MainPage;
		private BaseViewModel _TensePage;
		private BaseViewModel _FlashcardPage;
		private BaseViewModel _LibraryPage;


		#region Properties

		private BaseViewModel _currentViewModel;
		public BaseViewModel CurrentViewModel { get => _currentViewModel; set => Set(ref _currentViewModel, value); }


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
			CurrentViewModel = _MainPage ??= App.Services.GetRequiredService<MainWindowViewModel>();
		}

		private ICommand _OpenTensePageCommand;
		public ICommand OpenTensePageCommand => _OpenTensePageCommand 
			??= new RelayCommand(OnOpenTensePageCommandExecuted, CanOpenTensePageCommandExecute);

		private bool CanOpenTensePageCommandExecute(object p) => true;
		private void OnOpenTensePageCommandExecuted(object p)
		{
			CurrentViewModel = _TensePage ??= App.Services.GetRequiredService<TensePageViewModel>();
		}
		private ICommand _OpenFlashcardPageCommand;
		public ICommand OpenFlashcardPageCommand => _OpenFlashcardPageCommand
			  ??= new RelayCommand(OnOpenFlashcardPageCommandExecuted, CanOpenFlashcardPageCommandExecute);

		private bool CanOpenFlashcardPageCommandExecute(object p) => true;
		private void OnOpenFlashcardPageCommandExecuted(object p)
		{
			CurrentViewModel = _FlashcardPage ??= App.Services.GetRequiredService<FlashcardPageViewModel>();
		}

		private ICommand _OpenLibraryPageCommand;
		public ICommand OpenLibraryPageCommand => _OpenLibraryPageCommand
			??= new RelayCommand(OnOpenLibraryPageCommandExecuted, CanOpenLibraryPageCommandExecute);

		private bool CanOpenLibraryPageCommandExecute(object p) => true;
		private void OnOpenLibraryPageCommandExecuted(object p)
		{
			CurrentViewModel = _LibraryPage ??= App.Services.GetRequiredService<LibraryPageViewModel>();
		}
		#endregion


		public MainWindowViewModel()
		{
			CurrentViewModel = this;
		}
	}
}
