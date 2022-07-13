using JustEng.JustEngDAL.DatabaseContext;

using Microsoft.Extensions.Logging;

using System.Diagnostics;
using System.Threading.Tasks;

namespace JustEng.Data
{
	internal class DbInitializer
	{
		private readonly FlashcardsDBContext _db;
		private readonly ILogger<DbInitializer> _logger;

		public DbInitializer(FlashcardsDBContext db, ILogger<DbInitializer> logger)
		{
			_db = db;
			_logger = logger;
		}

		public async Task InitializeAsync()
		{
			var timer = Stopwatch.StartNew();
			//await _db.Database.MigrateAsync();
			await _db.Database.EnsureCreatedAsync().ConfigureAwait(false);
			_logger.LogInformation("База данных создана за {0} мс", timer.ElapsedMilliseconds);
		}
	}
}
