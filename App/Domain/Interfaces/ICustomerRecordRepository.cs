public interface ICustomerRecordRepository
{
    Task<IEnumerable<CustomerRecord>> GetAllAsync();
    Task<CustomerRecord> GetByIdAsync(Guid id);
    Task AddAsync(CustomerRecord customerRecord);
    Task UpdateAsync(CustomerRecord customerRecord);
    Task DeleteAsync(Guid id);
}