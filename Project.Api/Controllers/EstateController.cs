using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Api.Core.Application.Repositories;
using Project.Api.Core.Application.Services;
using Project.Api.Core.Domain.Entities;
using Project.Api.Core.Domain.Model;

namespace Project.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EstateController : ControllerBase
{
    private readonly ILogger<EstateController> _logger;
    private readonly IEstateService _estateService;
    private readonly IEstateTypeService _estateTypeService;


    public EstateController(ILogger<EstateController> logger,
        IEstateService estateService,
        IEstateTypeService estateTypeService)
    {
        _logger = logger;
        _estateService = estateService;
        _estateTypeService = estateTypeService;
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("estatetypes")]
    public async Task<IActionResult> EstateTypes()
    {
        _logger.LogInformation("EstateTypes method called.");

        var estateTypes = await _estateTypeService.GetAllAsync();
        
        if(!estateTypes.Any())
            return NotFound("EstateTypes not found");
       

        return Ok(estateTypes);
    }
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("estatetypes/{typeId}")]
    public async Task<IActionResult> EstateTypes([FromRoute] string typeId)
    {
        var estateType = await _estateTypeService.GetByIdAsync(typeId);

        return Ok(estateType);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("estatetypes")]
    public async Task<IActionResult> EstateTypes([FromBody] EstateTypeModel estateType)
    {
        var result = await _estateTypeService.AddAsync(estateType);
        
        HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
        return Ok(result);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("estates")]
    public async Task<IActionResult> Estates()
    {
        _logger.LogInformation("EstateTypes method called.");

        var estates = await _estateService.GetAllAsync();
        
        if(!estates.Any())
            return NotFound("EstateTypes not found");

        return Ok(estates);
    }
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("estates/{estateId}")]
    public async Task<IActionResult> Estates([FromRoute] string estateId)
    {
        var estate = await _estateService.GetByIdAsync(estateId);

        return Ok(estate);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("estates")]
    public async Task<IActionResult> Estates([FromBody] EstateModel estate)
    {
       await _estateService.AddAsync(estate);
        
        return Created();
    }
}