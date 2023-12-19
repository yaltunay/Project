

using Microsoft.EntityFrameworkCore;
using Project.Api.Core.Application.Repositories;
using Project.Api.Core.Application.Services;
using Project.Api.Core.Domain.Entities;
using Project.Api.Core.Domain.Model;

namespace Project.Api.Infrastructure.Persistence.Services;

public class CustomerTypeService : ICustomerTypeService
{
    private readonly ICustomerTypeRepository _customerTypeRepository;

    public CustomerTypeService(ICustomerTypeRepository customerTypeRepository)
    {
        _customerTypeRepository = customerTypeRepository;
    }


    public async Task<IEnumerable<CustomerTypeModel>> GetAllAsync()
    {
        var customerTypes = await _customerTypeRepository.GetAllAsync();

        var result = customerTypes
            .OrderByDescending(x => x.Name)
            .Select(x => new CustomerTypeModel
            {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description
        }).ToList();

        return result;
    }

    public async Task<CustomerTypeModel> GetByIdAsync(string typeId)
    {
        var customerType = await _customerTypeRepository.Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(typeId));
        return new()
        {
            Id = customerType.Id,
            Name = customerType.Name,
            Description = customerType.Description
        };
    }

    public async Task<CustomerTypeModel> AddAsync(CustomerTypeModel customerType)
    {
        var entity = new CustomerType
        {
            Name = customerType.Name,
            Description = customerType.Description
        };

        var result = await _customerTypeRepository.AddAsync(entity);

        return new()
        {
            Id = result.Id,
            Name = result.Name,
            Description = result.Description
        };
    }
}
