using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult<KpiResultDto>> GetEmployeeTurnoverRate()
    {
        var result = await _hrKpiService.CalculateEmployeeTurnoverRateAsync();
        return Ok(result);
    }

    [HttpGet("employee-satisfaction-index")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetEmployeeSatisfactionIndex()
    {
        var result = await _hrKpiService.CalculateEmployeeSatisfactionIndexAsync();
        return Ok(result);
    }

    [HttpGet("time-to-hire")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetTimeToHire()
    {
        var result = await _hrKpiService.CalculateTimeToHireAsync();
        return Ok(result);
    }

    [HttpGet("diversity-and-inclusion")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetDiversityAndInclusionMetrics()
    {
        var result = await _hrKpiService.CalculateDiversityAndInclusionMetricsAsync();
        return Ok(result);
    }

    [HttpGet("training-hours-per-employee")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetTrainingHoursPerEmployee()
    {
        var result = await _hrKpiService.CalculateTrainingHoursPerEmployeeAsync();
        return Ok(result);
    }

    [HttpGet("absenteeism-rate")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetAbsenteeismRate()
    {
        var result = await _hrKpiService.CalculateAbsenteeismRateAsync();
        return Ok(result);
    }

    [HttpGet("employee-productivity-rate")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetEmployeeProductivityRate()
    {
        var result = await _hrKpiService.CalculateEmployeeProductivityRateAsync();
        return Ok(result);
    }
}
