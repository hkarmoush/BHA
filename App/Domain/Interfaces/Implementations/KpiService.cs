using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class KpiService : IKpiService
{
    private readonly IKpiRepository _kpiRepository;

    public KpiService(IKpiRepository kpiRepository)
    {
        _kpiRepository = kpiRepository;
    }

    public async Task<IEnumerable<KpiDto>> GetKpisForUserRoleAsync(Role role)
    {
        var kpis = await _kpiRepository.GetKpisByRoleAsync(role);
        return kpis.Select(k => new KpiDto
        {
            Id = k.Id,
            Name = k.Name,
            Description = k.Description,
            Value = k.Value
        });
    }
}
