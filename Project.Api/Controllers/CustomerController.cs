using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Core.Application.Services;
using Project.Api.Core.Domain.Entities;
using Project.Api.Core.Domain.Model;
using Project.Api.Infrastructure.Persistence.Services;

namespace Project.Api.Controllers;
[Route("[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly ICustomerService _customerService;
    private readonly ICustomerTypeService _customerTypeService;

    public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService, ICustomerTypeService customerTypeService)
    {
        _logger = logger;
        _customerService = customerService;
        _customerTypeService = customerTypeService;
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("customertypes")]
    public async Task<IActionResult> CustomerTypes()
    {
        _logger.LogInformation("CustomerTypes method called.");

        var customerTypes = await _customerTypeService.GetAllAsync();

        if (!customerTypes.Any())
            return NotFound("CustomerTypes not found");


        return Ok(customerTypes);
    }
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("customertypes/{typeId}")]
    public async Task<IActionResult> CustomerTypes([FromRoute] string typeId)
    {
        var customerType = await _customerTypeService.GetByIdAsync(typeId);

        return Ok(customerType);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("customertypes")]
    public async Task<IActionResult> CustomerTypes([FromBody] CustomerTypeModel customerType)
    {
        await _customerTypeService.AddAsync(customerType);

        return Created();
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("customers")]
    public async Task<IActionResult> Customers()
    {
        _logger.LogInformation("Customers method called.");

        var customers = await _customerService.GetAllAsync();

        if (!customers.Any())
            return NotFound("Customers not found");

        return Ok(customers);
    }
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("customers/{customerId}")]
    public async Task<IActionResult> Customers([FromRoute] string customerId)
    {
        var customer = await _customerService.GetByIdAsync(customerId);

        return Ok(customer);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("customers")]
    public async Task<IActionResult> Customers([FromBody] CustomerModel customer)
    {
        await _customerService.AddAsync(customer);

        return Created();
    }
}
