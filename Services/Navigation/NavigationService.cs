using JustEng.ViewModels.Base;

using Microsoft.Extensions.DependencyInjection;

using System;

namespace JustEng.Services.Navigation
{
	public class NavigationService<T> : INavigationService
		where T : ViewModelBase
	{
		private readonly NavigationStore _navStore;
		private readonly IServiceProvider _service;

		public NavigationService(IServiceProvider service, NavigationStore navStore)
		{
			_navStore = navStore;
			_service = service;
		}
		public void Navigate()
		{
			_navStore.CurrentViewModel = _service.GetRequiredService<T>();
		}
	}
}
