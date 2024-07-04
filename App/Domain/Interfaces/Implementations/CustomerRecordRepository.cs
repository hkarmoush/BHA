using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class CustomerRecordRepository : ICustomerRecordRepository
{
    private readonly AppDbContext _context;

    public CustomerRecordRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CustomerRecord>> GetAllAsync()
    {
        return await _context.CustomerRecords.ToListAsync();
    }

    public async Task<CustomerRecord> GetByIdAsync(Guid id)
    {
        return await _context.CustomerRecords.FindAsync(id);
    }

    public async Task AddAsync(CustomerRecord customerRecord)
    {
        await _context.CustomerRecords.AddAsync(customerRecord);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CustomerRecord customerRecord)
    {
        _context.CustomerRecords.Update(customerRecord);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var customerRecord = await _context.CustomerRecords.FindAsync(id);
        if (customerRecord != null)
        {
            _context.CustomerRecords.Remove(customerRecord);
            await _context.SaveChangesAsync();
        }
    }
}