public interface IHRRecordService
{
    Task<IEnumerable<HRRecordDto>> GetHRRecordsAsync();
    Task<HRRecordDto> GetHRRecordByIdAsync(Guid id);
    Task AddHRRecordAsync(HRRecordDto hrRecordDto);
    Task UpdateHRRecordAsync(HRRecordDto hrRecordDto);
    Task DeleteHRRecordAsync(Guid id);
}