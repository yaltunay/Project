using Microsoft.EntityFrameworkCore;
using Project.Api.Core.Domain.Entities;

namespace Project.Api.Core.Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }

    Task<T> GetByIdAsync(Guid id);
    Task<List<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
}
