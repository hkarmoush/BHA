using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class ITRecordRepository : IITRecordRepository
{
    private readonly AppDbContext _context;

    public ITRecordRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ITRecord>> GetAllAsync()
    {
        return await _context.ITRecords.ToListAsync();
    }

    public async Task<ITRecord> GetByIdAsync(Guid id)
    {
        return await _context.ITRecords.FindAsync(id);
    }

    public async Task AddAsync(ITRecord itRecord)
    {
        await _context.ITRecords.AddAsync(itRecord);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ITRecord itRecord)
    {
        _context.ITRecords.Update(itRecord);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var itRecord = await _context.ITRecords.FindAsync(id);
        if (itRecord != null)
        {
            _context.ITRecords.Remove(itRecord);
            await _context.SaveChangesAsync();
        }
    }
}