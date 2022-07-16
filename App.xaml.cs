using JustEng.Data;
using JustEng.Services;
using JustEng.Services.Navigation;
using JustEng.ViewModels;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Linq;
using System.Windows;

namespace JustEng
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		private static IHost __Host;

		public static IHost Host => __Host
			??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

		public static IServiceProvider Services => Host.Services;

		public static IHostBuilder CreateHostBuilder(string[] args) => Microsoft.Extensions.Hosting.Host
		   .CreateDefaultBuilder(args)
		   .ConfigureServices(
				(hostContext, services) => services
				   .AddDatabase(hostContext.Configuration.GetSection("Database"))
				   .AddServices()
				   .AddViewModels()
			);

		protected override async void OnStartup(StartupEventArgs e)
		{
			var host = Host;

			using (var scope = Services.CreateScope())
				scope.ServiceProvider.GetRequiredService<DbInitializer>().InitializeAsync().Wait();

			NavigationStore navStore = Services.GetRequiredService<NavigationStore>();
			navStore.CurrentViewModel = Services.GetRequiredService<HomePageViewModel>();

			await host.StartAsync();
			base.OnStartup(e);
		}

		protected override async void OnExit(ExitEventArgs e)
		{
			using (var host = Host)
				await host.StopAsync();

			base.OnExit(e);
		}
	}
}