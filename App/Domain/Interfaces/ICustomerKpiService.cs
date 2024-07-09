public interface ICustomerKpiService
{
    Task<KpiResultDto> CalculateCustomerSatisfactionAsync();
    Task<KpiResultDto> CalculateCustomerRetentionRateAsync();
    Task<KpiResultDto> CalculateCustomerAcquisitionCostAsync();
    Task<KpiResultDto> CalculateCustomerLifetimeValueAsync();
    Task<KpiResultDto> CalculateCustomerProfitabilityAsync();
    Task<KpiResultDto> CalculateNetPromoterScoreAsync();
    Task<KpiResultDto> CalculateCustomerTurnoverRateAsync();
    Task<KpiResultDto> CalculateCustomerEffortScoreAsync();
}