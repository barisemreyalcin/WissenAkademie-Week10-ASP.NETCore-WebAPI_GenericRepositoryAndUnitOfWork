using GenericRepoAndUnitOfWork.Model;
using Microsoft.EntityFrameworkCore;

namespace GenericRepoAndUnitOfWork.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		public DbSet<User> Users { get; set; }
	}
}
