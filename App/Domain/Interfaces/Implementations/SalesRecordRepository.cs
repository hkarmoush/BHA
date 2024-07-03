using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class SalesRecordRepository : ISalesRecordRepository
{
    private readonly AppDbContext _context;

    public SalesRecordRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SalesRecord>> GetSalesRecordsAsync()
    {
        return await _context.SalesRecords.ToListAsync();
    }

    public async Task AddSalesRecordAsync(SalesRecord salesRecord)
    {
        await _context.SalesRecords.AddAsync(salesRecord);
        await _context.SaveChangesAsync();
    }
}