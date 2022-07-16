using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JustEng.Infrastructure.Commands.Base;
using JustEng.Services.Navigation;
using JustEng.ViewModels.Base;

namespace JustEng.Infrastructure.Commands
{
	public class NavigateCommand : CommandBase
	{
		private readonly INavigationService _navigationService;
		public NavigateCommand(INavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		public override bool CanExecute(object parameter) => true;

		public override void Execute(object parameter)
		{
			_navigationService.Navigate();
		}
	}
}
