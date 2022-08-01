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
				OnCurrentLibraryChanged();
			}
		}

		public event Action CurrentLibraryChanged;
		private void OnCurrentLibraryChanged()
		{
			CurrentLibraryChanged?.Invoke();
		}
	}
}
