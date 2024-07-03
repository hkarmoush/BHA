using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class HRRecordRepository : IHRRecordRepository
{
    private readonly AppDbContext _context;

    public HRRecordRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<HRRecord>> GetHRRecordsAsync()
    {
        return await _context.HRRecords.ToListAsync();
    }

    public async Task AddHRRecordAsync(HRRecord hrRecord)
    {
        await _context.HRRecords.AddAsync(hrRecord);
        await _context.SaveChangesAsync();
    }
}