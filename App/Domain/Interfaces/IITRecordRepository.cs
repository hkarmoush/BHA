public interface IITRecordRepository
{
    Task<IEnumerable<ITRecord>> GetAllAsync();
    Task<ITRecord> GetByIdAsync(Guid id);
    Task AddAsync(ITRecord itRecord);
    Task UpdateAsync(ITRecord itRecord);
    Task DeleteAsync(Guid id);
}
