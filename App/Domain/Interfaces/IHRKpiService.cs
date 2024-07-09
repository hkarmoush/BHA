public interface IHRKpiService
{
    Task<KpiResultDto> CalculateEmployeeTurnoverRateAsync();
    Task<KpiResultDto> CalculateEmployeeSatisfactionIndexAsync();
    Task<KpiResultDto> CalculateTimeToHireAsync();
    Task<KpiResultDto> CalculateDiversityAndInclusionMetricsAsync();
    Task<KpiResultDto> CalculateTrainingHoursPerEmployeeAsync();
    Task<KpiResultDto> CalculateAbsenteeismRateAsync();
    Task<KpiResultDto> CalculateEmployeeProductivityRateAsync();
}