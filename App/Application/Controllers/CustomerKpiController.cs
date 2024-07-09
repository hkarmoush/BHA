using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/customer-kpi/[controller]")]
public class CustomerKpiController : ControllerBase
{
    private readonly ICustomerKpiService _customerKpiService;

    public CustomerKpiController(ICustomerKpiService customerKpiService)
    {
        _customerKpiService = customerKpiService;
    }

    [HttpGet("customer-satisfaction")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetCustomerSatisfaction()
    {
        var result = await _customerKpiService.CalculateCustomerSatisfactionAsync();
        return Ok(result);
    }

    [HttpGet("customer-retention-rate")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetCustomerRetentionRate()
    {
        var result = await _customerKpiService.CalculateCustomerRetentionRateAsync();
        return Ok(result);
    }

    [HttpGet("customer-acquisition-cost")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetCustomerAcquisitionCost()
    {
        var result = await _customerKpiService.CalculateCustomerAcquisitionCostAsync();
        return Ok(result);
    }

    [HttpGet("customer-lifetime-value")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetCustomerLifetimeValue()
    {
        var result = await _customerKpiService.CalculateCustomerLifetimeValueAsync();
        return Ok(result);
    }

    [HttpGet("customer-profitability")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetCustomerProfitability()
    {
        var result = await _customerKpiService.CalculateCustomerProfitabilityAsync();
        return Ok(result);
    }

    [HttpGet("net-promoter-score")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetNetPromoterScore()
    {
        var result = await _customerKpiService.CalculateNetPromoterScoreAsync();
        return Ok(result);
    }

    [HttpGet("customer-turnover-rate")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetCustomerTurnoverRate()
    {
        var result = await _customerKpiService.CalculateCustomerTurnoverRateAsync();
        return Ok(result);
    }

    [HttpGet("customer-effort-score")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetCustomerEffortScore()
    {
        var result = await _customerKpiService.CalculateCustomerEffortScoreAsync();
        return Ok(result);
    }
}
