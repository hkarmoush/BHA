public interface IFinancialKpiService
{
    Task<decimal> CalculateNetIncomeAsync();
    Task<decimal> CalculateRevenuePerUserAsync(int totalUsers);
    Task<decimal> CalculateROCEAsync();
    Task<decimal> CalculateHumanCapitalValueAddedAsync(int totalEmployees);
    Task<decimal> CalculateSalesAsync();
    Task<decimal> CalculatePercentageRevenuePerMajorCustomerAsync(decimal majorCustomerRevenue);
    Task<decimal> CalculateROAAsync();
    Task<decimal> CalculateRevenuePerEmployeeAsync(int totalEmployees);
    Task<decimal> CalculateNetEarningsAsync();
    Task<decimal> CalculateSalesPerChannelAsync(Dictionary<string, decimal> channelSales);
    Task<decimal> CalculateDebtToEquityRatioAsync();
    Task<decimal> CalculateEnergyConsumptionAsync();
    Task<decimal> CalculateEBITAsync();
    Task<decimal> CalculateQuotationConversionRateAsync(int totalQuotations, int successfulQuotations);
    Task<decimal> CalculateCashConversionCycleAsync();
    Task<decimal> CalculateSavingLevelsAsync();
    Task<decimal> CalculateEBITDAAsync();
    Task<decimal> CalculateUpsellingSuccessRateAsync(int totalUpsells, int successfulUpsells);
    Task<decimal> CalculateWorkingCapitalRatioAsync();
    Task<decimal> CalculateRevenueAsync();
    Task<decimal> CalculateRiskLikelihoodVsConsequenceAsync();
    Task<decimal> CalculateReturnOnInvestmentAsync(decimal investmentCost, decimal returnAmount);
    Task<decimal> CalculateCrossSellingSuccessRateAsync(int totalCrossSells, int successfulCrossSells);
    Task<decimal> CalculateOperatingExpenseRatioAsync();
    Task<decimal> CalculateRevenueGrowthRateAsync();
    Task<decimal> CalculateRiskAppetiteVsExposureAsync();
    Task<decimal> CalculateEVAAsync();
    Task<decimal> CalculateCostToServeAsync();
    Task<decimal> CalculateCAPEXToSalesRatioAsync();
    Task<decimal> CalculateNetProfitAsync();
    Task<decimal> CalculateITCostsAsPercentageOfRevenueAsync(decimal totalITCosts);
    Task<decimal> CalculateTurnoverAsync();
    Task<decimal> CalculateAcquisitionRetentionSpendingRatioAsync();
    Task<decimal> CalculatePERatioAsync(decimal sharePrice, decimal earningsPerShare);
    Task<decimal> CalculateNetProfitMarginAsync();
    Task<decimal> CalculateITProjectCostVarianceAsync();
    Task<decimal> CalculateNetIncomeMarginAsync();
    Task<decimal> CalculateCostAvoidanceScoreAsync();
    Task<decimal> CalculateCustomerProfitabilityAsync();
    Task<decimal> CalculateGrossProfitMarginAsync();
    Task<decimal> CalculateSalesVolumeProjectionAsync();
    Task<decimal> CalculateReturnOnSalesAsync();
    Task<decimal> CalculateCustomerLifetimeValueAsync();
    Task<decimal> CalculateTotalShareholderReturnAsync(decimal sharePrice, decimal dividend);
    Task<decimal> CalculateDirectProductProfitabilityAsync();
    Task<decimal> CalculateOperatingProfitMarginAsync();
    Task<decimal> CalculateReturnOnInnovationInvestmentAsync();
}