public interface IKpiService
{
    Task<IEnumerable<KpiDto>> GetKpisForUserRoleAsync(Role role);
    Task<IEnumerable<KpiDto>> GetAllKpisAsync();
}