using Kindergarten.Application.Interfaces;
using Kindergarten.Application.Interfaces.Repositories;
using Kindergarten.Infrastructure.Persistence;
using Kindergarten.Infrastructure.Repositories;

namespace Kindergarten.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _ctx;
        private readonly Dictionary<Type, object> _repos = new();

        public UnitOfWork(AppDbContext ctx) { _ctx = ctx; }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            var type = typeof(T);
            if (_repos.TryGetValue(type, out var repo)) return (IGenericRepository<T>)repo;

            var constructed = Activator.CreateInstance(typeof(GenericRepository<>).MakeGenericType(type), _ctx)!;
            _repos[type] = constructed;
            return (IGenericRepository<T>)constructed;
        }

        public Task<int> SaveChangesAsync(CancellationToken ct = default) => _ctx.SaveChangesAsync(ct);

        public void Dispose() => _ctx.Dispose();
    }

}
