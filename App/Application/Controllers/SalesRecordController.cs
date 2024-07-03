using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SalesRecordController : ControllerBase
{
    private readonly ISalesRecordRepository _salesRecordRepository;

    public SalesRecordController(ISalesRecordRepository salesRecordRepository)
    {
        _salesRecordRepository = salesRecordRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SalesRecord>>> GetSalesRecords()
    {
        var salesRecords = await _salesRecordRepository.GetSalesRecordsAsync();
        return Ok(salesRecords);
    }

    [HttpPost]
    public async Task<ActionResult> AddSalesRecord(SalesRecord salesRecord)
    {
        await _salesRecordRepository.AddSalesRecordAsync(salesRecord);
        return Ok();
    }
}
