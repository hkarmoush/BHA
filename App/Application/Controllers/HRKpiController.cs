using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class HRKpiController : ControllerBase
{
    private readonly IHRKpiService _hrKpiService;

    public HRKpiController(IHRKpiService hrKpiService)
    {
        _hrKpiService = hrKpiService;
    }

    [HttpGet("employee-turnover-rate")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetEmployeeTurnoverRate()
    {
        var result = await _hrKpiService.CalculateEmployeeTurnoverRateAsync();
        return Ok(result);
    }

    [HttpGet("employee-satisfaction-index")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetEmployeeSatisfactionIndex()
    {
        var result = await _hrKpiService.CalculateEmployeeSatisfactionIndexAsync();
        return Ok(result);
    }

    [HttpGet("time-to-hire")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetTimeToHire()
    {
        var result = await _hrKpiService.CalculateTimeToHireAsync();
        return Ok(result);
    }

    [HttpGet("diversity-and-inclusion-metrics")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetDiversityAndInclusionMetrics()
    {
        var result = await _hrKpiService.CalculateDiversityAndInclusionMetricsAsync();
        return Ok(result);
    }

    [HttpGet("training-hours-per-employee")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetTrainingHoursPerEmployee()
    {
        var result = await _hrKpiService.CalculateTrainingHoursPerEmployeeAsync();
        return Ok(result);
    }

    [HttpGet("absenteeism-rate")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetAbsenteeismRate()
    {
        var result = await _hrKpiService.CalculateAbsenteeismRateAsync();
        return Ok(result);
    }

    [HttpGet("employee-productivity-rate")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetEmployeeProductivityRate()
    {
        var result = await _hrKpiService.CalculateEmployeeProductivityRateAsync();
        return Ok(result);
    }
}
