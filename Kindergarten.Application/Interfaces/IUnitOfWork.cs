using Kindergarten.Application.Interfaces.Repositories;

namespace Kindergarten.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;

        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}
