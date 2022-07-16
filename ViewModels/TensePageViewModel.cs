using JustEng.Infrastructure.Commands;
using JustEng.Models.Tenses;
using JustEng.ViewModels.Base;

using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace JustEng.ViewModels
{
	public class TensePageViewModel : ViewModelBase
	{
		#region Properties

		public ObservableCollection<JustEng.Models.Tenses.Base.TenseBase> Tenses { get; set; } = new();

		private int _currentTab = 0;
		public int CurrentTab { get => _currentTab; set => Set(ref _currentTab, value); }

		public PresentModel Present { get; set; } = new();
		public PastModel Past { get; set; } = new();
		public FutureModel Future { get; set; } = new();

		#endregion

		public TensePageViewModel()
		{
			Tenses.Add(Present);
			Tenses.Add(Past);
			Tenses.Add(Future);
		}
	}
}
