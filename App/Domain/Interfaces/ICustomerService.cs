public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetCustomersAsync();
    Task<CustomerDto> GetCustomerByIdAsync(Guid id);
    Task AddCustomerAsync(CustomerDto customerDto);
    Task UpdateCustomerAsync(CustomerDto customerDto);
    Task DeleteCustomerAsync(Guid id);
}