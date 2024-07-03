public interface IKpiRepository
{
    Task<IEnumerable<Kpi>> GetKpisByRoleAsync(Role role);
    Task AddKpiAsync(Kpi kpi);
    Task UpdateKpiAsync(Kpi kpi);
    Task DeleteKpiAsync(Guid id);
}