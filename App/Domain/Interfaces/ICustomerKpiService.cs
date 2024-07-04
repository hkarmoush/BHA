public interface ICustomerKpiService
{
    Task<decimal> CalculateCustomerSatisfactionAsync();
    Task<decimal> CalculateCustomerRetentionRateAsync();
    Task<decimal> CalculateCustomerAcquisitionCostAsync();
    Task<decimal> CalculateCustomerLifetimeValueAsync();
    Task<decimal> CalculateCustomerProfitabilityAsync();
    Task<decimal> CalculateNetPromoterScoreAsync();
    Task<decimal> CalculateCustomerTurnoverRateAsync();
    Task<decimal> CalculateCustomerEffortScoreAsync();
}