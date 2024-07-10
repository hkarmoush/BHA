public interface IITKpiService
{
    Task<KpiResultDto> CalculateITProjectEarnedValueAsync();
    Task<KpiResultDto> CalculateNumberOfITSecurityBreachesAsync();
    Task<KpiResultDto> CalculateITCostsAsPercentageOfRevenueAsync();
    Task<KpiResultDto> CalculateHelpDeskFirstCallResolutionAsync();
    Task<KpiResultDto> CalculateInternalITServiceSatisfactionScoreAsync();
    Task<KpiResultDto> CalculateITProjectCostVarianceAsync();
    Task<KpiResultDto> CalculateEnterpriseArchitectureComplianceRatioAsync();
    Task<KpiResultDto> CalculateAverageAgeOfITInfrastructureAsync();
    Task<KpiResultDto> CalculateIncidentResolutionIndexAsync();
    Task<KpiResultDto> CalculateWebsiteNonAvailabilityAsync();
    Task<KpiResultDto> CalculateITProjectScheduleVarianceAsync();
    Task<KpiResultDto> CalculateITMaintenanceRatioAsync();
    Task<KpiResultDto> CalculateAverageAgeOfSoftwareAsync();
    Task<KpiResultDto> CalculateSystemDowntimeAsync();
}