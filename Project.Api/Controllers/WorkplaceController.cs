using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Core.Application.Services;
using Project.Api.Core.Domain.Model;

namespace Project.Api.Controllers;
[Route("[controller]")]
[ApiController]
public class WorkplaceController : ControllerBase
{
    private readonly ILogger<WorkplaceController> _logger;
    private readonly IWorkplaceService _workplaceService;

    public WorkplaceController(ILogger<WorkplaceController> logger, IWorkplaceService workplaceService)
    {
        _logger = logger;
        _workplaceService = workplaceService;
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("workplaces")]
    public async Task<IActionResult> Workplaces()
    {
            _logger.LogInformation("Workplaces method called.");

            var workplaces = await _workplaceService.GetAllAsync();

            if (!workplaces.Any())
                return NotFound("Workplaces not found");

            return Ok(workplaces);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("workplaces/{workplaceId}")]
    public async Task<IActionResult> Workplaces([FromRoute] string workplaceId)
    {
        var workplace = await _workplaceService.GetByIdAsync(workplaceId);

        return Ok(workplace);
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("workplaces")]
    public async Task<IActionResult> Workplaces([FromBody] WorkplaceModel workplace)
    {
        await _workplaceService.AddAsync(workplace);

        return Created();
    }
}
