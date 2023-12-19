using Microsoft.EntityFrameworkCore;
using Project.Api.Core.Application.Repositories;
using Project.Api.Core.Application.Services;
using Project.Api.Core.Domain.Entities;
using Project.Api.Core.Domain.Model;

namespace Project.Api.Infrastructure.Persistence.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<IEnumerable<CustomerModel>> GetAllAsync()
    {
        var customers = await _customerRepository.GetAllAsync();

        var result = customers
            .OrderByDescending(x => x.Name)
            .Select(customer => new CustomerModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Phone = customer.Phone,
                Surname = customer.Surname,
                CustomerTypeId = customer.CustomerTypeId,
                Email = customer.Email,
                Mobile = customer.Mobile,
                CreatedDate = customer.CreatedDate,
                UpdatedDate = customer.UpdatedDate,
                IsActive = customer.IsActive,
                IsDeleted = customer.IsDeleted
            }).ToList();

        return result;
    }

    public async Task<CustomerModel> GetByIdAsync(string customerId)
    {
        var customer = await _customerRepository.Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(customerId));
        return new CustomerModel
        {
            Id = customer.Id,
            Name = customer.Name,
            Surname = customer.Surname,
            Phone = customer.Phone,
            CustomerTypeId = customer.CustomerTypeId,
            Email = customer.Email,
            Mobile = customer.Mobile,
            CreatedDate = customer.CreatedDate,
            UpdatedDate = customer.UpdatedDate,
            IsActive = customer.IsActive,
            IsDeleted = customer.IsDeleted
        };
    }

    public async Task<CustomerModel> AddAsync(CustomerModel customer)
    {
        var entity = new Customer
        {
            Name = customer.Name,
            Surname = customer.Surname,
            Phone = customer.Phone,
            CustomerTypeId = customer.CustomerTypeId,
            Email = customer.Email,
            Mobile = customer.Mobile
        };

        var result = await _customerRepository.AddAsync(entity);

        return new()
        {
            Id = result.Id,
            Name = result.Name,
            Surname = result.Surname,
            Phone = result.Phone,
            CustomerTypeId = result.CustomerTypeId,
            Email = result.Email,
            Mobile = result.Mobile,
            CreatedDate = result.CreatedDate,
            UpdatedDate = result.UpdatedDate,
            IsActive = result.IsActive,
            IsDeleted = result.IsDeleted
        };
    }
}
