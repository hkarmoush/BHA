public interface ISalesRecordRepository
{
    Task<IEnumerable<SalesRecord>> GetSalesRecordsAsync();
    Task AddSalesRecordAsync(SalesRecord salesRecord);
}