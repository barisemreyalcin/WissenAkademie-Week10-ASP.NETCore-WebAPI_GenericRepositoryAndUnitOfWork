using GenericRepoAndUnitOfWork.Core.IConfiguration;
using GenericRepoAndUnitOfWork.Core.IRepository;
using GenericRepoAndUnitOfWork.Core.Repository;

namespace GenericRepoAndUnitOfWork.Data
{
	public class UnitOfWork : IUnitOfWork, IDisposable 
	{
		private AppDbContext context;
		private ILogger logger;

		public IUserRepository Users
		{
			get;
			private set; // Dışardan instance alınıp set edilemeyecek. Constructor'da yapacam
		}

		public UnitOfWork(AppDbContext _context, ILoggerFactory _logger)
		{
			this.context = _context;
			this.logger = _logger.CreateLogger("ApplicationLogs");

			// Reponun instance'si
			this.Users = new UserRepository(context, logger);
		}

		public async Task CompleteAsync()
		{
			await context.SaveChangesAsync();
		}

		public void Dispose() // IDisposable'dan (GarbageCollector çalışsın diye)
		{
			context.Dispose();
		}
	}
}
