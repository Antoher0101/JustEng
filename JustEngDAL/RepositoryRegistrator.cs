using JustEng.JustEngDAL.Entities;

using JustEng.JustEngInterfaces;

using Microsoft.Extensions.DependencyInjection;

namespace JustEng.JustEngDAL
{
	public static class RepositoryRegistrator
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services) => services
			.AddTransient<IRepository<Flashcard>, DbRepository<Flashcard>>()
			.AddTransient<IRepository<Library>, LibrariesRepository>()
		;
	}
}
