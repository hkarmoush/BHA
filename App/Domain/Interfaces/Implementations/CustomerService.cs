using AutoMapper;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerDto>> GetCustomersAsync()
    {
        var customers = await _customerRepository.GetCustomersAsync();
        return _mapper.Map<IEnumerable<CustomerDto>>(customers);
    }

    public async Task<CustomerDto> GetCustomerByIdAsync(Guid id)
    {
        var customer = await _customerRepository.GetCustomerByIdAsync(id);
        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task AddCustomerAsync(CustomerDto customerDto)
    {
        var customer = _mapper.Map<Customer>(customerDto);
        await _customerRepository.AddCustomerAsync(customer);
    }

    public async Task UpdateCustomerAsync(CustomerDto customerDto)
    {
        var customer = _mapper.Map<Customer>(customerDto);
        await _customerRepository.UpdateCustomerAsync(customer);
    }

    public async Task DeleteCustomerAsync(Guid id)
    {
        await _customerRepository.DeleteCustomerAsync(id);
    }
}