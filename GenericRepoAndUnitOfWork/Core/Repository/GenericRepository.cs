using System.Linq.Expressions;
using GenericRepoAndUnitOfWork.Core.IRepository;
using GenericRepoAndUnitOfWork.Data;
using Microsoft.EntityFrameworkCore;

namespace GenericRepoAndUnitOfWork.Core.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		public AppDbContext context;
		public DbSet<T> dbSet;
		public ILogger logger;

		public GenericRepository(AppDbContext _context, ILogger _logger)
		{
			this.context = _context;
			this.logger = _logger;

			this.dbSet = context.Set<T>();
		}	

		public async Task<bool> AddAsync(T entity)
		{
			await dbSet.AddAsync(entity);
			return true;
		}

		public virtual Task<bool> DeleteAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter)
		{
			return await dbSet.Where(filter).ToListAsync();
		}

		public virtual Task<IEnumerable<T>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<T> GetByIdAsync(Guid id)
		{
			return await dbSet.FindAsync(id);
		}

		public virtual Task<bool> UpdateAsync(T entity)
		{
			throw new NotImplementedException();
		}
	}
}
