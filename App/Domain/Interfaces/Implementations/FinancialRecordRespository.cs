using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class FinancialRecordRepository : IFinancialRecordRepository
{
    private readonly AppDbContext _context;

    public FinancialRecordRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FinancialRecord>> GetFinancialRecordsAsync()
    {
        return await _context.FinancialRecords.ToListAsync();
    }

    public async Task AddFinancialRecordAsync(FinancialRecord financialRecord)
    {
        await _context.FinancialRecords.AddAsync(financialRecord);
        await _context.SaveChangesAsync();
    }
}