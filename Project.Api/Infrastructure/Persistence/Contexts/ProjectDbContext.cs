using Microsoft.EntityFrameworkCore;
using Project.Api.Core.Domain.Entities;

namespace Project.Api.Infrastructure.Persistence.Contexts;

public class ProjectDbContext : DbContext
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Estate> Estates { get; set; }
    public DbSet<EstateType> EstateTypes { get; set; }
    public DbSet<CustomerType> CustomerTypes { get; set; }
    public DbSet<Workplace> Workplaces { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var data in ChangeTracker.Entries<BaseEntity>())
        {
            switch (data.State)
            {
                case EntityState.Added:
                    data.Entity.Id = Guid.NewGuid();
                    data.Entity.CreatedDate = DateTime.Now;
                    data.Entity.IsDeleted = false;
                    data.Entity.IsActive = true;
                    break;
                case EntityState.Modified:
                    data.Entity.UpdatedDate = DateTime.Now;
                    break;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
