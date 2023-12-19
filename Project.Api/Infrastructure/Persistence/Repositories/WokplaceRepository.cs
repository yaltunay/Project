using Project.Api.Core.Application.Repositories;
using Project.Api.Core.Domain.Entities;
using Project.Api.Infrastructure.Persistence.Contexts;

namespace Project.Api.Infrastructure.Persistence.Repositories;

public class WorkplaceRepository : Repository<Workplace>, IWorkplaceRepository
{
    public WorkplaceRepository(ProjectDbContext context) : base(context)
    {
    }
}
