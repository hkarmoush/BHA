public interface ICustomerRecordService
{
    Task<IEnumerable<CustomerRecordDto>> GetCustomerRecordsAsync();
    Task<CustomerRecordDto> GetCustomerRecordByIdAsync(Guid id);
    Task AddCustomerRecordAsync(CustomerRecordDto customerRecordDto);
    Task UpdateCustomerRecordAsync(CustomerRecordDto customerRecordDto);
    Task DeleteCustomerRecordAsync(Guid id);
}