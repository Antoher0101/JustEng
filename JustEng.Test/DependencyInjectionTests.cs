using JustEng.ViewModels;

using Microsoft.Extensions.DependencyInjection;

namespace JustEng.Test
{
	public class DependencyInjectionTests
	{
		[Fact]
		public void Get_Service_MainWindowViewModel_Is_Not_Null()
		{
			var actual = App.Services.GetRequiredService<MainWindowViewModel>();
			Assert.NotNull(actual);
		}
		[Fact]
		public void Get_Service_LibraryPageViewModel_Is_Not_Null()
		{
			var actual = App.Services.GetRequiredService<LibraryPageViewModel>();
			Assert.NotNull(actual);
		}
		[Fact]
		public void Get_Service_FlashcardPageViewModel_Is_Not_Null()
		{
			var actual = App.Services.GetRequiredService<FlashcardPageViewModel>();
			Assert.NotNull(actual);
		}
		[Fact]
		public void Get_Service_TensePageViewModel_Is_Not_Null()
		{
			var actual = App.Services.GetRequiredService<TensePageViewModel>();
			Assert.NotNull(actual);
		}
	}
}