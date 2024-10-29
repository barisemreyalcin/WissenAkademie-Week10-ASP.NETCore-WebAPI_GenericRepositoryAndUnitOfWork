using GenericRepoAndUnitOfWork.Core.IRepository;
using GenericRepoAndUnitOfWork.Data;
using GenericRepoAndUnitOfWork.Model;
using Microsoft.EntityFrameworkCore;

namespace GenericRepoAndUnitOfWork.Core.Repository
{
	public class UserRepository : GenericRepository<User>, IUserRepository
	{
		public UserRepository(AppDbContext _context, ILogger _logger):base (_context, _logger)
		{

		}

		// GenericRepository'de implement etmediğim metodları burda edebilirim
		public override async Task<IEnumerable<User>> GetAllAsync()
		{
			try
			{
				return await dbSet.ToListAsync();
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "User Repository GetAllAsync Method Error", typeof(UserRepository));
				return new List<User>();
			}
		}

		public override async Task<bool> DeleteAsync(Guid id)
		{
			try
			{
				User user = await dbSet.Where(x => x.UserId == id).FirstOrDefaultAsync();
				if(user == null)
					return false;

				dbSet.Remove(user);
				return true;
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "User Repository DeleteAsync Method Error", typeof(UserRepository));
				return false;
			}
		}

		public override async Task<bool> UpdateAsync(User entity)
		{
			try
			{
				User existingUser = await dbSet.Where(x => x.UserId == entity.UserId).FirstOrDefaultAsync();
				if (existingUser == null)
					return await AddAsync(entity);

				existingUser.FirstName = entity.FirstName;
				existingUser.LastName = entity.LastName;
				existingUser.Email = entity.Email;
				existingUser.Phone = entity.Phone;
				existingUser.Address = entity.Address;
				return true;
			}
			catch(Exception ex)
			{
				logger.LogError(ex, "User Repository UpdateAsync Method Error", typeof(UserRepository));
				return false;
			}
		}
	}
}
