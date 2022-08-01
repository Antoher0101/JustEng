using System;
using JustEng.Infrastructure.Commands;
using JustEng.ViewModels.Base;
using JustEng.Views.Pages;

using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using JustEng.Services.Navigation;
using JustEng.Services.Stores;

namespace JustEng.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		#region Properties

		public ViewModelBase CurrentViewModel => _navStore.CurrentViewModel;

		#endregion

		public ICommand OpenLibraryPageCommand { get; }
		public ICommand OpenTensePageCommand { get; }
		public ICommand OpenHomePageCommand { get; }

		private readonly NavigationStore _navStore;

		public MainWindowViewModel(NavigationStore navigationStore, 
			NavigationService<LibraryPageViewModel> libraryNav, 
			NavigationService<TensePageViewModel> tenseNav,
			NavigationService<HomePageViewModel> homeNav)
		{
			_navStore = navigationStore;

			OpenLibraryPageCommand = new NavigateCommand(libraryNav);
			OpenTensePageCommand = new NavigateCommand(tenseNav);
			OpenHomePageCommand = new NavigateCommand(homeNav);

			_navStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
		}

		private void OnCurrentViewModelChanged()
		{
			OnPropertyChanged(nameof(CurrentViewModel));
		}
	}
}
