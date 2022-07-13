using JustEng.Infrastructure.Commands;
using JustEng.Models.Tenses;
using JustEng.ViewModels.Base;

using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace JustEng.ViewModels
{
	public class TensePageViewModel : BaseViewModel
	{
		#region Properties

		public ObservableCollection<JustEng.Models.Tenses.Base.TenseBase> Tenses { get; set; } = new();

		private int _currentTab = 0;
		public int CurrentTab { get => _currentTab; set => Set(ref _currentTab, value); }

		public PresentModel Present { get; set; } = new();
		public PastModel Past { get; set; } = new();
		public FutureModel Future { get; set; } = new();
		#endregion

		public ICommand AnyCommand { get; }

		private bool CanAnyCommandExecute(object p) => true;
		private void OnAnyCommandExecuted(object p)
		{
			Console.WriteLine("it works");
		}

		#region commands
		

		#endregion
		public TensePageViewModel()
		{
			#region Init commands

			AnyCommand = new RelayCommand(OnAnyCommandExecuted, CanAnyCommandExecute);
			
			#endregion

			Tenses.Add(Present);
			Tenses.Add(Past);
			Tenses.Add(Future);

			
		}
	}
}
