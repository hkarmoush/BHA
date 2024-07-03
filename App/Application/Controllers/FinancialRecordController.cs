using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FinancialRecordController : ControllerBase
{
    private readonly IFinancialRecordRepository _financialRecordRepository;

    public FinancialRecordController(IFinancialRecordRepository financialRecordRepository)
    {
        _financialRecordRepository = financialRecordRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FinancialRecord>>> GetFinancialRecords()
    {
        var financialRecords = await _financialRecordRepository.GetFinancialRecordsAsync();
        return Ok(financialRecords);
    }

    [HttpPost]
    public async Task<ActionResult> AddFinancialRecord(FinancialRecord financialRecord)
    {
        await _financialRecordRepository.AddFinancialRecordAsync(financialRecord);
        return Ok();
    }
}
