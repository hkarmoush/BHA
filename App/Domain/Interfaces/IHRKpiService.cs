public interface IHRKpiService
{
    Task<decimal> CalculateEmployeeTurnoverRateAsync();
    Task<decimal> CalculateEmployeeSatisfactionIndexAsync();
    Task<decimal> CalculateTimeToHireAsync();
    Task<decimal> CalculateDiversityAndInclusionMetricsAsync();
    Task<decimal> CalculateTrainingHoursPerEmployeeAsync();
    Task<decimal> CalculateAbsenteeismRateAsync();
    Task<decimal> CalculateEmployeeProductivityRateAsync();
}