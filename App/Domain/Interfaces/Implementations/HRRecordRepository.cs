using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class HRRecordRepository : IHRRecordRepository
{
    private readonly AppDbContext _context;

    public HRRecordRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<HRRecord>> GetAllAsync()
    {
        return await _context.HRRecords.ToListAsync();
    }

    public async Task<HRRecord> GetByIdAsync(Guid id)
    {
        return await _context.HRRecords.FindAsync(id);
    }

    public async Task AddAsync(HRRecord hrRecord)
    {
        await _context.HRRecords.AddAsync(hrRecord);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(HRRecord hrRecord)
    {
        _context.HRRecords.Update(hrRecord);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var hrRecord = await _context.HRRecords.FindAsync(id);
        if (hrRecord != null)
        {
            _context.HRRecords.Remove(hrRecord);
            await _context.SaveChangesAsync();
        }
    }
}
