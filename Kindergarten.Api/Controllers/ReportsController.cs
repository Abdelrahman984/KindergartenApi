// Api/Controllers/ReportsController.cs
using Kindergarten.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kindergarten.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly IReportsService _reportsService;

    public ReportsController(IReportsService reportsService)
    {
        _reportsService = reportsService;
    }

    [HttpGet("overview")]
    public async Task<IActionResult> GetOverview()
    {
        var report = await _reportsService.GetOverviewAsync();
        return Ok(report);
    }
}
