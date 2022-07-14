using JustEng.JustEngDAL.DatabaseContext;

using Microsoft.Extensions.Logging;

using System.Diagnostics;
using System.Threading.Tasks;

namespace JustEng.Data
{
	internal class DbInitializer
	{
		private readonly LibraryDBContext _db;
		private readonly ILogger<DbInitializer> _logger;

		public DbInitializer(LibraryDBContext db, ILogger<DbInitializer> logger)
		{
			_db = db;
			_logger = logger;
		}

		public async Task InitializeAsync()
		{
			var timer = Stopwatch.StartNew();
			await _db.Database.EnsureCreatedAsync().ConfigureAwait(false);
			_logger.LogInformation("The database was initialized in {0} ms", timer.ElapsedMilliseconds);
		}
	}
}