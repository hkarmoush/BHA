public interface IKpiService
{
    Task<IEnumerable<KpiDto>> GetKpisForUserRoleAsync(Role role);
}