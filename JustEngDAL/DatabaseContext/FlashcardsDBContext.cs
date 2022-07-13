using JustEng.JustEngDAL.Entities;

using Microsoft.EntityFrameworkCore;

namespace JustEng.JustEngDAL.DatabaseContext
{
	public class FlashcardsDBContext : DbContext
	{
		private DbSet<Flashcard> Flashcards { get; set; }
		public FlashcardsDBContext(DbContextOptions options) : base(options) { }
	}
}
