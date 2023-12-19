using Project.Api.Core.Application.Repositories;
using Project.Api.Core.Domain.Entities;
using Project.Api.Infrastructure.Persistence.Contexts;

namespace Project.Api.Infrastructure.Persistence.Repositories;

public class CustomerTypeRepository : Repository<CustomerType>, ICustomerTypeRepository
{
    public CustomerTypeRepository(ProjectDbContext context) : base(context)
    {
    }
}