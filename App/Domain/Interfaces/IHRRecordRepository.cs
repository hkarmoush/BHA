
public interface IHRRecordRepository
{
    Task<IEnumerable<HRRecord>> GetAllAsync();
    Task<HRRecord> GetByIdAsync(Guid id);
    Task AddAsync(HRRecord hrRecord);
    Task UpdateAsync(HRRecord hrRecord);
    Task DeleteAsync(Guid id);
}