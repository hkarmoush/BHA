using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CustomerRecordController : ControllerBase
{
    private readonly ICustomerRecordService _customerRecordService;

    public CustomerRecordController(ICustomerRecordService customerRecordService)
    {
        _customerRecordService = customerRecordService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<CustomerRecordDto>>> GetCustomerRecords()
    {
        var customerRecords = await _customerRecordService.GetCustomerRecordsAsync();
        return Ok(customerRecords);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<CustomerRecordDto>> GetCustomerRecordById(Guid id)
    {
        var customerRecord = await _customerRecordService.GetCustomerRecordByIdAsync(id);
        if (customerRecord == null)
        {
            return NotFound();
        }
        return Ok(customerRecord);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult> AddCustomerRecord(CustomerRecordDto customerRecordDto)
    {
        await _customerRecordService.AddCustomerRecordAsync(customerRecordDto);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult> UpdateCustomerRecord(Guid id, CustomerRecordDto customerRecordDto)
    {
        if (id != customerRecordDto.Id)
        {
            return BadRequest();
        }

        await _customerRecordService.UpdateCustomerRecordAsync(customerRecordDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult> DeleteCustomerRecord(Guid id)
    {
        await _customerRecordService.DeleteCustomerRecordAsync(id);
        return Ok();
    }
}
