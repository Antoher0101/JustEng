using JustEng.JustEngDAL;
using JustEng.JustEngDAL.DatabaseContext;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;

namespace JustEng.Data
{
	static class DbRegistrator
	{
		public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) => services
			.AddDbContext<FlashcardsDBContext>(opt =>
			{
				var type = configuration["Type"];
				switch (type)
				{
					case "SQLite":
						opt.UseSqlite(configuration.GetConnectionString(type));
						break;

					case null: throw new InvalidOperationException("DB Type is not defined");
					default: throw new InvalidOperationException($"Connection type {type} is not supported");
				}
			})
			.AddTransient<DbInitializer>()
			.AddRepositories()
		;
	}
}
