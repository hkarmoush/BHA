using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/financial-kpis")]
public class FinancialKpiController : ControllerBase
{
    private readonly IFinancialKpiService _kpiService;

    public FinancialKpiController(IFinancialKpiService kpiService)
    {
        _kpiService = kpiService;
    }

    [HttpGet("net-income")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetNetIncome()
    {
        var result = await _kpiService.CalculateNetIncomeAsync();
        return Ok(result);
    }

    [HttpGet("revenue-per-user/{totalUsers}")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetRevenuePerUser(int totalUsers)
    {
        var result = await _kpiService.CalculateRevenuePerUserAsync(totalUsers);
        return Ok(result);
    }

    [HttpGet("roce")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetROCE()
    {
        var result = await _kpiService.CalculateROCEAsync();
        return Ok(result);
    }

    [HttpGet("human-capital-value-added/{totalEmployees}")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetHumanCapitalValueAdded(int totalEmployees)
    {
        var result = await _kpiService.CalculateHumanCapitalValueAddedAsync(totalEmployees);
        return Ok(result);
    }

    [HttpGet("sales")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetSales()
    {
        var result = await _kpiService.CalculateSalesAsync();
        return Ok(result);
    }

    [HttpGet("percentage-revenue-per-major-customer/{majorCustomerRevenue}")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetPercentageRevenuePerMajorCustomer(decimal majorCustomerRevenue)
    {
        var result = await _kpiService.CalculatePercentageRevenuePerMajorCustomerAsync(majorCustomerRevenue);
        return Ok(result);
    }

    [HttpGet("roa")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetROA()
    {
        var result = await _kpiService.CalculateROAAsync();
        return Ok(result);
    }

    [HttpGet("revenue-per-employee/{totalEmployees}")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetRevenuePerEmployee(int totalEmployees)
    {
        var result = await _kpiService.CalculateRevenuePerEmployeeAsync(totalEmployees);
        return Ok(result);
    }

    [HttpGet("net-earnings")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetNetEarnings()
    {
        var result = await _kpiService.CalculateNetEarningsAsync();
        return Ok(result);
    }

    [HttpGet("sales-per-channel")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetSalesPerChannel([FromQuery] Dictionary<string, decimal> channelSales)
    {
        var result = await _kpiService.CalculateSalesPerChannelAsync(channelSales);
        return Ok(result);
    }

    [HttpGet("debt-to-equity-ratio")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetDebtToEquityRatio()
    {
        var result = await _kpiService.CalculateDebtToEquityRatioAsync();
        return Ok(result);
    }

    [HttpGet("energy-consumption")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetEnergyConsumption()
    {
        var result = await _kpiService.CalculateEnergyConsumptionAsync();
        return Ok(result);
    }

    [HttpGet("ebit")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetEBIT()
    {
        var result = await _kpiService.CalculateEBITAsync();
        return Ok(result);
    }

    [HttpGet("quotation-conversion-rate/{totalQuotations}/{successfulQuotations}")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetQuotationConversionRate(int totalQuotations, int successfulQuotations)
    {
        var result = await _kpiService.CalculateQuotationConversionRateAsync(totalQuotations, successfulQuotations);
        return Ok(result);
    }

    [HttpGet("cash-conversion-cycle")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetCashConversionCycle()
    {
        var result = await _kpiService.CalculateCashConversionCycleAsync();
        return Ok(result);
    }

    [HttpGet("saving-levels")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetSavingLevels()
    {
        var result = await _kpiService.CalculateSavingLevelsAsync();
        return Ok(result);
    }

    [HttpGet("ebitda")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetEBITDA()
    {
        var result = await _kpiService.CalculateEBITDAAsync();
        return Ok(result);
    }

    [HttpGet("upselling-success-rate/{totalUpsells}/{successfulUpsells}")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetUpsellingSuccessRate(int totalUpsells, int successfulUpsells)
    {
        var result = await _kpiService.CalculateUpsellingSuccessRateAsync(totalUpsells, successfulUpsells);
        return Ok(result);
    }

    [HttpGet("working-capital-ratio")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetWorkingCapitalRatio()
    {
        var result = await _kpiService.CalculateWorkingCapitalRatioAsync();
        return Ok(result);
    }

    [HttpGet("revenue")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetRevenue()
    {
        var result = await _kpiService.CalculateRevenueAsync();
        return Ok(result);
    }

    [HttpGet("risk-likelihood-vs-consequence")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetRiskLikelihoodVsConsequence()
    {
        var result = await _kpiService.CalculateRiskLikelihoodVsConsequenceAsync();
        return Ok(result);
    }

    [HttpGet("return-on-investment/{investmentCost}/{returnAmount}")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetReturnOnInvestment(decimal investmentCost, decimal returnAmount)
    {
        var result = await _kpiService.CalculateReturnOnInvestmentAsync(investmentCost, returnAmount);
        return Ok(result);
    }

    [HttpGet("cross-selling-success-rate/{totalCrossSells}/{successfulCrossSells}")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetCrossSellingSuccessRate(int totalCrossSells, int successfulCrossSells)
    {
        var result = await _kpiService.CalculateCrossSellingSuccessRateAsync(totalCrossSells, successfulCrossSells);
        return Ok(result);
    }

    [HttpGet("operating-expense-ratio")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetOperatingExpenseRatio()
    {
        var result = await _kpiService.CalculateOperatingExpenseRatioAsync();
        return Ok(result);
    }

    [HttpGet("revenue-growth-rate")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetRevenueGrowthRate()
    {
        var result = await _kpiService.CalculateRevenueGrowthRateAsync();
        return Ok(result);
    }

    [HttpGet("risk-appetite-vs-exposure")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetRiskAppetiteVsExposure()
    {
        var result = await _kpiService.CalculateRiskAppetiteVsExposureAsync();
        return Ok(result);
    }

    [HttpGet("eva")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetEVA()
    {
        var result = await _kpiService.CalculateEVAAsync();
        return Ok(result);
    }

    [HttpGet("cost-to-serve")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetCostToServe()
    {
        var result = await _kpiService.CalculateCostToServeAsync();
        return Ok(result);
    }

    [HttpGet("capex-to-sales-ratio")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetCAPEXToSalesRatio()
    {
        var result = await _kpiService.CalculateCAPEXToSalesRatioAsync();
        return Ok(result);
    }

    [HttpGet("net-profit")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetNetProfit()
    {
        var result = await _kpiService.CalculateNetProfitAsync();
        return Ok(result);
    }

    [HttpGet("it-costs-as-percentage-of-revenue/{totalITCosts}")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetITCostsAsPercentageOfRevenue(decimal totalITCosts)
    {
        var result = await _kpiService.CalculateITCostsAsPercentageOfRevenueAsync(totalITCosts);
        return Ok(result);
    }

    [HttpGet("turnover")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetTurnover()
    {
        var result = await _kpiService.CalculateTurnoverAsync();
        return Ok(result);
    }

    [HttpGet("acquisition-retention-spending-ratio")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetAcquisitionRetentionSpendingRatio()
    {
        var result = await _kpiService.CalculateAcquisitionRetentionSpendingRatioAsync();
        return Ok(result);
    }

    [HttpGet("pe-ratio/{sharePrice}/{earningsPerShare}")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetPERatio(decimal sharePrice, decimal earningsPerShare)
    {
        var result = await _kpiService.CalculatePERatioAsync(sharePrice, earningsPerShare);
        return Ok(result);
    }

    [HttpGet("net-profit-margin")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetNetProfitMargin()
    {
        var result = await _kpiService.CalculateNetProfitMarginAsync();
        return Ok(result);
    }

    [HttpGet("it-project-cost-variance")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetITProjectCostVariance()
    {
        var result = await _kpiService.CalculateITProjectCostVarianceAsync();
        return Ok(result);
    }

    [HttpGet("net-income-margin")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetNetIncomeMargin()
    {
        var result = await _kpiService.CalculateNetIncomeMarginAsync();
        return Ok(result);
    }

    [HttpGet("cost-avoidance-score")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetCostAvoidanceScore()
    {
        var result = await _kpiService.CalculateCostAvoidanceScoreAsync();
        return Ok(result);
    }

    [HttpGet("customer-profitability")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetCustomerProfitability()
    {
        var result = await _kpiService.CalculateCustomerProfitabilityAsync();
        return Ok(result);
    }

    [HttpGet("gross-profit-margin")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetGrossProfitMargin()
    {
        var result = await _kpiService.CalculateGrossProfitMarginAsync();
        return Ok(result);
    }

    [HttpGet("sales-volume-projection")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetSalesVolumeProjection()
    {
        var result = await _kpiService.CalculateSalesVolumeProjectionAsync();
        return Ok(result);
    }

    [HttpGet("return-on-sales")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetReturnOnSales()
    {
        var result = await _kpiService.CalculateReturnOnSalesAsync();
        return Ok(result);
    }

    [HttpGet("customer-lifetime-value")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetCustomerLifetimeValue()
    {
        var result = await _kpiService.CalculateCustomerLifetimeValueAsync();
        return Ok(result);
    }

    [HttpGet("total-shareholder-return/{sharePrice}/{dividend}")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetTotalShareholderReturn(decimal sharePrice, decimal dividend)
    {
        var result = await _kpiService.CalculateTotalShareholderReturnAsync(sharePrice, dividend);
        return Ok(result);
    }

    [HttpGet("direct-product-profitability")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetDirectProductProfitability()
    {
        var result = await _kpiService.CalculateDirectProductProfitabilityAsync();
        return Ok(result);
    }

    [HttpGet("operating-profit-margin")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetOperatingProfitMargin()
    {
        var result = await _kpiService.CalculateOperatingProfitMarginAsync();
        return Ok(result);
    }

    [HttpGet("return-on-innovation-investment")]
    [Authorize]
    public async Task<ActionResult<decimal>> GetReturnOnInnovationInvestment()
    {
        var result = await _kpiService.CalculateReturnOnInnovationInvestmentAsync();
        return Ok(result);
    }
}
