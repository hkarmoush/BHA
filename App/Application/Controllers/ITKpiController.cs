using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ITKpiController : ControllerBase
{
    private readonly IITKpiService _itKpiService;

    public ITKpiController(IITKpiService itKpiService)
    {
        _itKpiService = itKpiService;
    }

    [HttpGet("project-earned-value")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetITProjectEarnedValue()
    {
        var kpi = await _itKpiService.CalculateITProjectEarnedValueAsync();
        return Ok(kpi);
    }

    [HttpGet("number-of-security-breaches")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetNumberOfITSecurityBreaches()
    {
        var kpi = await _itKpiService.CalculateNumberOfITSecurityBreachesAsync();
        return Ok(kpi);
    }

    [HttpGet("it-costs-percentage-revenue")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetITCostsAsPercentageOfRevenue()
    {
        var kpi = await _itKpiService.CalculateITCostsAsPercentageOfRevenueAsync();
        return Ok(kpi);
    }

    [HttpGet("help-desk-first-call-resolution")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetHelpDeskFirstCallResolution()
    {
        var kpi = await _itKpiService.CalculateHelpDeskFirstCallResolutionAsync();
        return Ok(kpi);
    }

    [HttpGet("internal-it-service-satisfaction-score")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetInternalITServiceSatisfactionScore()
    {
        var kpi = await _itKpiService.CalculateInternalITServiceSatisfactionScoreAsync();
        return Ok(kpi);
    }

    [HttpGet("it-project-cost-variance")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetITProjectCostVariance()
    {
        var kpi = await _itKpiService.CalculateITProjectCostVarianceAsync();
        return Ok(kpi);
    }

    [HttpGet("enterprise-architecture-compliance-ratio")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetEnterpriseArchitectureComplianceRatio()
    {
        var kpi = await _itKpiService.CalculateEnterpriseArchitectureComplianceRatioAsync();
        return Ok(kpi);
    }

    [HttpGet("average-age-it-infrastructure")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetAverageAgeOfITInfrastructure()
    {
        var kpi = await _itKpiService.CalculateAverageAgeOfITInfrastructureAsync();
        return Ok(kpi);
    }

    [HttpGet("incident-resolution-index")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetIncidentResolutionIndex()
    {
        var kpi = await _itKpiService.CalculateIncidentResolutionIndexAsync();
        return Ok(kpi);
    }

    [HttpGet("website-non-availability")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetWebsiteNonAvailability()
    {
        var kpi = await _itKpiService.CalculateWebsiteNonAvailabilityAsync();
        return Ok(kpi);
    }

    [HttpGet("it-project-schedule-variance")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetITProjectScheduleVariance()
    {
        var kpi = await _itKpiService.CalculateITProjectScheduleVarianceAsync();
        return Ok(kpi);
    }

    [HttpGet("it-maintenance-ratio")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetITMaintenanceRatio()
    {
        var kpi = await _itKpiService.CalculateITMaintenanceRatioAsync();
        return Ok(kpi);
    }

    [HttpGet("average-age-software")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetAverageAgeOfSoftware()
    {
        var kpi = await _itKpiService.CalculateAverageAgeOfSoftwareAsync();
        return Ok(kpi);
    }

    [HttpGet("system-downtime")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetSystemDowntime()
    {
        var kpi = await _itKpiService.CalculateSystemDowntimeAsync();
        return Ok(kpi);
    }
}
