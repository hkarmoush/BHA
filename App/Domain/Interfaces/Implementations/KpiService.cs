public class KpiService : IKpiService
{
    private readonly IKpiRepository _kpiRepository;
    private readonly ISalesRecordRepository _salesRecordRepository;

    public KpiService(IKpiRepository kpiRepository, ISalesRecordRepository salesRecordRepository)
    {
        _kpiRepository = kpiRepository;
        _salesRecordRepository = salesRecordRepository;
    }

    public async Task<IEnumerable<KpiDto>> GetKpisForUserRoleAsync(Role role)
    {
        var kpis = await _kpiRepository.GetKpisByRoleAsync(role);
        var salesRecords = await _salesRecordRepository.GetSalesRecordsAsync();

        // Calculate each KPI based on historical data
        foreach (var kpi in kpis)
        {
            if (kpi.Name == "Total Sales")
            {
                kpi.Value = salesRecords.Sum(sr => sr.Amount).ToString("C");
            }
            else if (kpi.Name == "Sales Growth")
            {
                // Implement your sales growth calculation logic
            }
            // Add more KPI calculations as needed
        }

        return kpis.Select(k => new KpiDto
        {
            Id = k.Id,
            Name = k.Name,
            Description = k.Description,
            Value = k.Value
        });
    }
}