using System.Linq.Expressions;

namespace GenericRepoAndUnitOfWork.Core.IRepository
{
	public interface IGenericRepository<T> where T : class // bu type'ın class olduğunu belirtir
	{
		Task<IEnumerable<T>> GetAllAsync();

		Task<T> GetByIdAsync(Guid id);
		Task<bool> AddAsync(T entity); // bool olmak zorunda değil T de döndürebiliriz
		Task<bool> UpdateAsync(T entity);
		Task<bool> DeleteAsync(Guid id);
		Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter); // lambda expression yazmak için böyle yaparız

	}
}
