
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

public class KpiRepository : IKpiRepository
{
    private readonly AppDbContext _context;

    public KpiRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Kpi>> GetKpisByRoleAsync(Role role)
    {
        return await _context.Kpis.Where(k => k.Role == role).ToListAsync();
    }
    public async Task<IEnumerable<Kpi>> GetAllKpisAsync()
    {
        return await _context.Kpis.ToListAsync();
    }

    public async Task AddKpiAsync(Kpi kpi)
    {
        await _context.Kpis.AddAsync(kpi);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateKpiAsync(Kpi kpi)
    {
        _context.Kpis.Update(kpi);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteKpiAsync(Guid id)
    {
        var kpi = await _context.Kpis.FindAsync(id);
        if (kpi != null)
        {
            _context.Kpis.Remove(kpi);
            await _context.SaveChangesAsync();
        }
    }
}
