using JustEng.Data;
using JustEng.Services;
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
		public static Window ActiveWindow => Application.Current.Windows
		   .OfType<Window>()
		   .FirstOrDefault(w => w.IsActive);

		public static Window FocusedWindow => Application.Current.Windows
		   .OfType<Window>()
		   .FirstOrDefault(w => w.IsFocused);

		public static Window CurrentWindow => FocusedWindow ?? ActiveWindow;

		public static bool IsDesignTime { get; private set; } = true;

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
			IsDesignTime = false;

			var host = Host;

			using (var scope = Services.CreateScope())
				scope.ServiceProvider.GetRequiredService<DbInitializer>().InitializeAsync().Wait();

			base.OnStartup(e);
			await host.StartAsync();
		}

		protected override async void OnExit(ExitEventArgs e)
		{
			using var host = Host;
			base.OnExit(e);
			await host.StopAsync();
		}
	}
}