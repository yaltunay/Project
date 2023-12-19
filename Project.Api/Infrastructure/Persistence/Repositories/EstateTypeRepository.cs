using Project.Api.Core.Application.Repositories;
using Project.Api.Core.Domain.Entities;
using Project.Api.Infrastructure.Persistence.Contexts;

namespace Project.Api.Infrastructure.Persistence.Repositories;

public class EstateTypeRepository : Repository<EstateType>, IEstateTypeRepository
{
    public EstateTypeRepository(ProjectDbContext context) : base(context)
    {
    }
}