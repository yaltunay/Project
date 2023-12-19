using Project.Api.Core.Domain.Model;

namespace Project.Api.Core.Application.Services;

public interface ICustomerService
{
    Task<IEnumerable<CustomerModel>> GetAllAsync();
    Task<CustomerModel> GetByIdAsync(string customerId);
    Task<CustomerModel> AddAsync(CustomerModel customer);
}
