using GenericRepoAndUnitOfWork.Model;

namespace GenericRepoAndUnitOfWork.Core.IRepository
{
	public interface IUserRepository : IGenericRepository<User>
	{
		// IGenericRepository'tekileri kullanabilir veya ezip kendine özgü kullanabilir
		//Task<bool> UpdateAsync(Guid id, User user);
	}
}
