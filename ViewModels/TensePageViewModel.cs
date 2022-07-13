using JustEng.Models.Tenses;
using JustEng.ViewModels.Base;

using System.Collections.ObjectModel;

namespace JustEng.ViewModels
{
	internal class TensePageViewModel : BaseViewModel
	{
		#region Properties

		public ObservableCollection<JustEng.Models.Tenses.Base.TenseBase> Tenses { get; set; } = new ObservableCollection<Models.Tenses.Base.TenseBase>();

		private int _currentTab = 0;
		public int CurrentTab { get => _currentTab; set => Set(ref _currentTab, value); }

		#endregion
		public TensePageViewModel()
		{
			Tenses.Add(new PresentModel());
			Tenses.Add(new PastModel());
			Tenses.Add(new FutureModel());
		}
	}
}
