public interface IFinancialRecordRepository
{
    Task<IEnumerable<FinancialRecord>> GetFinancialRecordsAsync();
    Task AddFinancialRecordAsync(FinancialRecord financialRecord);
}