using JustEng.JustEngDAL.DatabaseContext;
using JustEng.JustEngDAL.Entities.Base;
using JustEng.JustEngInterfaces;

using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JustEng.JustEngDAL.Entities;

namespace JustEng.JustEngDAL
{
	internal class DbRepository<T> : IRepository<T> where T : Entity, new()
	{
		private readonly LibraryDBContext _db;
		private readonly DbSet<T> _set;

		public bool AutoSaveChanges { get; set; } = true;

		public DbRepository(LibraryDBContext db)
		{
			_db = db;
			_set = db.Set<T>();
		}

		public virtual IQueryable<T> Items => _set;

		public T Add(T item)
		{
			if (item is null) throw new ArgumentNullException(nameof(item));
			_db.Entry(item).State = EntityState.Added;
			if (AutoSaveChanges)
				_db.SaveChanges();
			return item;
		}
		public async Task<T> AddAsync(T item, CancellationToken Cancel = default)
		{
			if (item is null) throw new ArgumentNullException(nameof(item));
			_db.Entry(item).State = EntityState.Added;
			if (AutoSaveChanges)
				_db.SaveChangesAsync(Cancel).ConfigureAwait(false);
			return item;
		}
		public T Delete(int id)
		{
			var item = new T() { Id = id };
			_db.Remove(item);
			if (AutoSaveChanges)
				_db.SaveChanges();
			return item;
		}
		public async Task<T> DeleteAsync(int id, CancellationToken Cancel = default)
		{
			var item = new T() { Id = id };
			_db.Remove(item);
			if (AutoSaveChanges)
				_db.SaveChangesAsync(Cancel);
			return item;
		}
		public T Get(int id) => Items.SingleOrDefault(item => item.Id == id);
		public async Task<T> GetAsync(int id, CancellationToken Cancel = default) => await Items
			.SingleOrDefaultAsync(item => item.Id == id, Cancel)
			.ConfigureAwait(false);
		public T Update(T item)
		{
			if (item is null) throw new ArgumentNullException(nameof(item));
			_db.Entry(item).State = EntityState.Modified;
			if (AutoSaveChanges)
				_db.SaveChanges();
			return item;
		}
		public async Task<T> UpdateAsync(T item, CancellationToken Cancel = default)
		{
			if (item is null) throw new ArgumentNullException(nameof(item));
			_db.Entry(item).State = EntityState.Modified;
			if (AutoSaveChanges)
				_db.SaveChangesAsync(Cancel);
			return item;
		}
	}

	internal class LibrariesRepository : DbRepository<Library>
	{
		public override IQueryable<Library> Items => base.Items.Include(item => item.Flashcards);
		public LibrariesRepository(LibraryDBContext db) : base(db) { }
	}
}
