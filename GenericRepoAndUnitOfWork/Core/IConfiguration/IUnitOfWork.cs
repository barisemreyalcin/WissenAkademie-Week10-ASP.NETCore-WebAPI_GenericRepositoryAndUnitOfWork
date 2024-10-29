using GenericRepoAndUnitOfWork.Core.IRepository;

namespace GenericRepoAndUnitOfWork.Core.IConfiguration
{
	public interface IUnitOfWork
	{
		IUserRepository Users{ get; } // Dışardan instance yapılmasına engel olup UnitOfWork ile kullanmasını sağlamak

		// Değişiklikleri dbye yansıtacak yapı
		// Kaç repom varsa tanımlamam gerekecek
		Task CompleteAsync();
	}
}
