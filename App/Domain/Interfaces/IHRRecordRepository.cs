
public interface IHRRecordRepository
{
    Task<IEnumerable<HRRecord>> GetHRRecordsAsync();
    Task AddHRRecordAsync(HRRecord hrRecord);
}