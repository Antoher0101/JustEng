using JustEng.JustEngDAL;
using JustEng.JustEngDAL.DatabaseContext;
using JustEng.JustEngDAL.Entities;

using Microsoft.EntityFrameworkCore;

namespace JustEng.Test
{
	public class DatabaseTests
	{
		public LibraryDBContext CreateDbContext()
		{
			var options = new DbContextOptionsBuilder<LibraryDBContext>()
			   .UseSqlite("Data Source=JustEngDAL\\database\\Test.db").Options;
			var dbContext = new LibraryDBContext(options);
			dbContext.Database.EnsureDeleted();
			dbContext.Database.EnsureCreated();
			return dbContext;
		}
		[Fact]
		public void It_should_add_a_library_successfully_into_database()
		{
			//Arrange
			var dbContext = CreateDbContext();
			var sut = new DbRepository<Library>(dbContext);
			var library = new Library(){Name = "TestLibrary"};
			//Act
			var result = sut.Add(library);

			//Assert
			Assert.True(result.Id > 0, "result.Id > 0");
			//Clean up
			dbContext.Dispose();
		}
		[Fact]
		public void It_should_update_a_library_successfully_into_database()
		{
			//Arrange
			var expected = "TestLibrary";
			var dbContext = CreateDbContext();
			var sut = new DbRepository<Library>(dbContext);
			var library = new Library() { Name = "TestLibrary" };
			//Act
			var result = sut.Add(library);
			result.Name = expected;
			sut.Update(result);
			result = dbContext.Libraries.First(p => p.Name == result.Name);
			//Assert
			Assert.Equal(expected, result.Name);
			//Clean up
			dbContext.Dispose();
		}
		[Fact]
		public void It_should_remove_a_library_successfully_from_the_database()
		{
			//Arrange
			var dbContext = CreateDbContext();
			var sut = new DbRepository<Library>(dbContext);
			var library = new Library() { Name = "TestLibrary" };
			//Act
			var result = sut.Add(library);
			sut.Delete(result.Id);
			var isExists = dbContext.Libraries.Any(p => p.Id == result.Id);
			//Assert
			Assert.False(isExists);
			//Clean up
			dbContext.Dispose();
		}
	}
}
