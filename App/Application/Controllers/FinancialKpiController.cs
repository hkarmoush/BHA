using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FinancialKpiController : ControllerBase
{
    private readonly IFinancialKpiService _financialKpiService;

    public FinancialKpiController(IFinancialKpiService financialKpiService)
    {
        _financialKpiService = financialKpiService;
    }

    [HttpGet("net-income")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetNetIncome()
    {
        var result = await _financialKpiService.CalculateNetIncomeAsync();
        return Ok(result);
    }

    [HttpGet("revenue-per-user")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetRevenuePerUser(int totalUsers)
    {
        var result = await _financialKpiService.CalculateRevenuePerUserAsync(totalUsers);
        return Ok(result);
    }

    [HttpGet("roce")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetROCE()
    {
        var result = await _financialKpiService.CalculateROCEAsync();
        return Ok(result);
    }

    [HttpGet("human-capital-value-added")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetHumanCapitalValueAdded(int totalEmployees)
    {
        var result = await _financialKpiService.CalculateHumanCapitalValueAddedAsync(totalEmployees);
        return Ok(result);
    }

    [HttpGet("sales")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetSales()
    {
        var result = await _financialKpiService.CalculateSalesAsync();
        return Ok(result);
    }

    [HttpGet("percentage-revenue-per-major-customer")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetPercentageRevenuePerMajorCustomer(decimal majorCustomerRevenue)
    {
        var result = await _financialKpiService.CalculatePercentageRevenuePerMajorCustomerAsync(majorCustomerRevenue);
        return Ok(result);
    }

    [HttpGet("roa")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetROA()
    {
        var result = await _financialKpiService.CalculateROAAsync();
        return Ok(result);
    }

    [HttpGet("revenue-per-employee")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetRevenuePerEmployee(int totalEmployees)
    {
        var result = await _financialKpiService.CalculateRevenuePerEmployeeAsync(totalEmployees);
        return Ok(result);
    }

    [HttpGet("net-earnings")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetNetEarnings()
    {
        var result = await _financialKpiService.CalculateNetEarningsAsync();
        return Ok(result);
    }

    [HttpGet("sales-per-channel")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetSalesPerChannel([FromBody] Dictionary<string, decimal> channelSales)
    {
        var result = await _financialKpiService.CalculateSalesPerChannelAsync(channelSales);
        return Ok(result);
    }

    [HttpGet("debt-to-equity-ratio")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetDebtToEquityRatio()
    {
        var result = await _financialKpiService.CalculateDebtToEquityRatioAsync();
        return Ok(result);
    }

    [HttpGet("energy-consumption")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetEnergyConsumption()
    {
        var result = await _financialKpiService.CalculateEnergyConsumptionAsync();
        return Ok(result);
    }

    [HttpGet("ebit")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetEBIT()
    {
        var result = await _financialKpiService.CalculateEBITAsync();
        return Ok(result);
    }

    [HttpGet("quotation-conversion-rate")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetQuotationConversionRate(int totalQuotations, int successfulQuotations)
    {
        var result = await _financialKpiService.CalculateQuotationConversionRateAsync(totalQuotations, successfulQuotations);
        return Ok(result);
    }

    [HttpGet("cash-conversion-cycle")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetCashConversionCycle()
    {
        var result = await _financialKpiService.CalculateCashConversionCycleAsync();
        return Ok(result);
    }

    [HttpGet("saving-levels")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetSavingLevels()
    {
        var result = await _financialKpiService.CalculateSavingLevelsAsync();
        return Ok(result);
    }

    [HttpGet("ebitda")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetEBITDA()
    {
        var result = await _financialKpiService.CalculateEBITDAAsync();
        return Ok(result);
    }

    [HttpGet("upselling-success-rate")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetUpsellingSuccessRate(int totalUpsells, int successfulUpsells)
    {
        var result = await _financialKpiService.CalculateUpsellingSuccessRateAsync(totalUpsells, successfulUpsells);
        return Ok(result);
    }

    [HttpGet("working-capital-ratio")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetWorkingCapitalRatio()
    {
        var result = await _financialKpiService.CalculateWorkingCapitalRatioAsync();
        return Ok(result);
    }

    [HttpGet("revenue")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetRevenue()
    {
        var result = await _financialKpiService.CalculateRevenueAsync();
        return Ok(result);
    }

    [HttpGet("risk-likelihood-vs-consequence")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetRiskLikelihoodVsConsequence()
    {
        var result = await _financialKpiService.CalculateRiskLikelihoodVsConsequenceAsync();
        return Ok(result);
    }

    [HttpGet("return-on-investment")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetReturnOnInvestment(decimal investmentCost, decimal returnAmount)
    {
        var result = await _financialKpiService.CalculateReturnOnInvestmentAsync(investmentCost, returnAmount);
        return Ok(result);
    }

    [HttpGet("cross-selling-success-rate")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetCrossSellingSuccessRate(int totalCrossSells, int successfulCrossSells)
    {
        var result = await _financialKpiService.CalculateCrossSellingSuccessRateAsync(totalCrossSells, successfulCrossSells);
        return Ok(result);
    }

    [HttpGet("operating-expense-ratio")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetOperatingExpenseRatio()
    {
        var result = await _financialKpiService.CalculateOperatingExpenseRatioAsync();
        return Ok(result);
    }

    [HttpGet("revenue-growth-rate")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetRevenueGrowthRate()
    {
        var result = await _financialKpiService.CalculateRevenueGrowthRateAsync();
        return Ok(result);
    }

    [HttpGet("risk-appetite-vs-exposure")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetRiskAppetiteVsExposure()
    {
        var result = await _financialKpiService.CalculateRiskAppetiteVsExposureAsync();
        return Ok(result);
    }

    [HttpGet("eva")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetEVA()
    {
        var result = await _financialKpiService.CalculateEVAAsync();
        return Ok(result);
    }

    [HttpGet("cost-to-serve")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetCostToServe()
    {
        var result = await _financialKpiService.CalculateCostToServeAsync();
        return Ok(result);
    }

    [HttpGet("capex-to-sales-ratio")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetCAPEXToSalesRatio()
    {
        var result = await _financialKpiService.CalculateCAPEXToSalesRatioAsync();
        return Ok(result);
    }

    [HttpGet("net-profit")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetNetProfit()
    {
        var result = await _financialKpiService.CalculateNetProfitAsync();
        return Ok(result);
    }

    [HttpGet("it-costs-as-percentage-of-revenue")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetITCostsAsPercentageOfRevenue(decimal totalITCosts)
    {
        var result = await _financialKpiService.CalculateITCostsAsPercentageOfRevenueAsync(totalITCosts);
        return Ok(result);
    }

    [HttpGet("turnover")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetTurnover()
    {
        var result = await _financialKpiService.CalculateTurnoverAsync();
        return Ok(result);
    }

    [HttpGet("acquisition-retention-spending-ratio")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetAcquisitionRetentionSpendingRatio()
    {
        var result = await _financialKpiService.CalculateAcquisitionRetentionSpendingRatioAsync();
        return Ok(result);
    }

    [HttpGet("pe-ratio")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetPERatio(decimal sharePrice, decimal earningsPerShare)
    {
        var result = await _financialKpiService.CalculatePERatioAsync(sharePrice, earningsPerShare);
        return Ok(result);
    }

    [HttpGet("net-profit-margin")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetNetProfitMargin()
    {
        var result = await _financialKpiService.CalculateNetProfitMarginAsync();
        return Ok(result);
    }

    [HttpGet("it-project-cost-variance")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetITProjectCostVariance()
    {
        var result = await _financialKpiService.CalculateITProjectCostVarianceAsync();
        return Ok(result);
    }

    [HttpGet("net-income-margin")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetNetIncomeMargin()
    {
        var result = await _financialKpiService.CalculateNetIncomeMarginAsync();
        return Ok(result);
    }

    [HttpGet("cost-avoidance-score")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetCostAvoidanceScore()
    {
        var result = await _financialKpiService.CalculateCostAvoidanceScoreAsync();
        return Ok(result);
    }

    [HttpGet("customer-profitability")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetCustomerProfitability()
    {
        var result = await _financialKpiService.CalculateCustomerProfitabilityAsync();
        return Ok(result);
    }

    [HttpGet("gross-profit-margin")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetGrossProfitMargin()
    {
        var result = await _financialKpiService.CalculateGrossProfitMarginAsync();
        return Ok(result);
    }

    [HttpGet("sales-volume-projection")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetSalesVolumeProjection()
    {
        var result = await _financialKpiService.CalculateSalesVolumeProjectionAsync();
        return Ok(result);
    }

    [HttpGet("return-on-sales")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetReturnOnSales()
    {
        var result = await _financialKpiService.CalculateReturnOnSalesAsync();
        return Ok(result);
    }

    [HttpGet("customer-lifetime-value")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetCustomerLifetimeValue()
    {
        var result = await _financialKpiService.CalculateCustomerLifetimeValueAsync();
        return Ok(result);
    }

    [HttpGet("total-shareholder-return")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetTotalShareholderReturn(decimal sharePrice, decimal dividend)
    {
        var result = await _financialKpiService.CalculateTotalShareholderReturnAsync(sharePrice, dividend);
        return Ok(result);
    }

    [HttpGet("direct-product-profitability")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetDirectProductProfitability()
    {
        var result = await _financialKpiService.CalculateDirectProductProfitabilityAsync();
        return Ok(result);
    }

    [HttpGet("operating-profit-margin")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetOperatingProfitMargin()
    {
        var result = await _financialKpiService.CalculateOperatingProfitMarginAsync();
        return Ok(result);
    }

    [HttpGet("return-on-innovation-investment")]
    [Authorize]
    public async Task<ActionResult<KpiResultDto>> GetReturnOnInnovationInvestment()
    {
        var result = await _financialKpiService.CalculateReturnOnInnovationInvestmentAsync();
        return Ok(result);
    }
}
