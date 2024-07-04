using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

public class CustomerRecordService : ICustomerRecordService
{
    private readonly ICustomerRecordRepository _customerRecordRepository;
    private readonly IMapper _mapper;

    public CustomerRecordService(ICustomerRecordRepository customerRecordRepository, IMapper mapper)
    {
        _customerRecordRepository = customerRecordRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerRecordDto>> GetCustomerRecordsAsync()
    {
        var customerRecords = await _customerRecordRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CustomerRecordDto>>(customerRecords);
    }

    public async Task<CustomerRecordDto> GetCustomerRecordByIdAsync(Guid id)
    {
        var customerRecord = await _customerRecordRepository.GetByIdAsync(id);
        return _mapper.Map<CustomerRecordDto>(customerRecord);
    }

    public async Task AddCustomerRecordAsync(CustomerRecordDto customerRecordDto)
    {
        var customerRecord = _mapper.Map<CustomerRecord>(customerRecordDto);
        await _customerRecordRepository.AddAsync(customerRecord);
    }

    public async Task UpdateCustomerRecordAsync(CustomerRecordDto customerRecordDto)
    {
        var customerRecord = _mapper.Map<CustomerRecord>(customerRecordDto);
        await _customerRecordRepository.UpdateAsync(customerRecord);
    }

    public async Task DeleteCustomerRecordAsync(Guid id)
    {
        await _customerRecordRepository.DeleteAsync(id);
    }
}
