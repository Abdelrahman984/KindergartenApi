using Kindergarten.Application.Interfaces.Repositories;
using Kindergarten.Domain.Entities;
using Kindergarten.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Infrastructure.Repositories;

public class ParentRepository : GenericRepository<Parent>, IParentRepository
{
    public ParentRepository(AppDbContext context) : base(context) { }

    public async Task<Parent?> GetWithChildrenAsync(Guid parentId)
        => await _dbSet.Include(p => p.Childrens).FirstOrDefaultAsync(p => p.Id == parentId);

    public async Task<Parent?> GetByPhoneAsync(string phoneNumber)
        => await _dbSet.FirstOrDefaultAsync(p => p.PhoneNumber == phoneNumber);

}
