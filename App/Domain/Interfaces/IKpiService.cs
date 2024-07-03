using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IKpiService
{
    Task<IEnumerable<KpiDto>> GetKpisForUserRoleAsync(Role role);
}