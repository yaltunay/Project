using Microsoft.EntityFrameworkCore;
using Project.Api.Core.Application.Repositories;
using Project.Api.Core.Domain.Entities;
using Project.Api.Infrastructure.Persistence.Contexts;

namespace Project.Api.Infrastructure.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly ProjectDbContext _context;

    public Repository(ProjectDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public Task<T> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<T>> GetAllAsync()
    {
        var query = Table.AsQueryable();
        return await query.ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        _context.Add(entity);

        await _context.SaveChangesAsync();

        return entity;
    }
}
