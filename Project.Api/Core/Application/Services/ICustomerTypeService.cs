using Project.Api.Core.Domain.Model;

namespace Project.Api.Core.Application.Services;

public interface ICustomerTypeService
{
    Task<IEnumerable<CustomerTypeModel>> GetAllAsync();
    Task<CustomerTypeModel> GetByIdAsync(string typeId);
    Task<CustomerTypeModel> AddAsync(CustomerTypeModel customerType);
}
