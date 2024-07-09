public interface IITRecordService
{
    Task<IEnumerable<ITRecordDto>> GetAllAsync();
    Task<ITRecordDto> GetByIdAsync(Guid id);
    Task AddAsync(ITRecordDto itRecordDto);
    Task UpdateAsync(ITRecordDto itRecordDto);
    Task DeleteAsync(Guid id);
}