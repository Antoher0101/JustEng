using JustEng.JustEngDAL.Entities;

using Microsoft.EntityFrameworkCore;

namespace JustEng.JustEngDAL.DatabaseContext
{
	public class FlashcardsDBContext : DbContext
	{
		/// <summary>
		/// The name is the same as the table in the db file
		/// </summary>
		private DbSet<Flashcard> Flashcards { get; set; }
		public FlashcardsDBContext(DbContextOptions options) : base(options) { }
	}
}