using JustEng.JustEngDAL.Entities;

using System;

namespace JustEng.Services.Stores
{
	public class LibraryStore
	{
		private Library _CurrentLibrary;

		public Library CurrentLibrary
		{
			get => _CurrentLibrary;
			set
			{
				_CurrentLibrary = value;
				OnCurrentViewModelChanged();
			}
		}

		public event Action CurrentViewModelChanged;
		private void OnCurrentViewModelChanged()
		{
			CurrentViewModelChanged?.Invoke();
		}
	}
}
