using JustEng.JustEngDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace JustEng.JustEngDAL.DatabaseContext
{
	public class LibraryDBContext : DbContext
	{
		public DbSet<Library> Libraries { get; set; }
		public DbSet<Flashcard> Flashcards { get; set; }

		public LibraryDBContext(DbContextOptions<LibraryDBContext> options) : base(options) { }
	}
}
