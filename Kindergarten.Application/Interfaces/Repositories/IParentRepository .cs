using Kindergarten.Domain.Entities;

namespace Kindergarten.Application.Interfaces.Repositories;

public interface IParentRepository : IGenericRepository<Parent>
{
    Task<Parent?> GetWithChildrenAsync(Guid parentId);
    Task<Parent?> GetByPhoneAsync(string phoneNumber);
}
