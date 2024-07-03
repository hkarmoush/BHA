
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HRRecordController : ControllerBase
{
    private readonly IHRRecordRepository _hrRecordRepository;

    public HRRecordController(IHRRecordRepository hrRecordRepository)
    {
        _hrRecordRepository = hrRecordRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<HRRecord>>> GetHRRecords()
    {
        var hrRecords = await _hrRecordRepository.GetHRRecordsAsync();
        return Ok(hrRecords);
    }

    [HttpPost]
    public async Task<ActionResult> AddHRRecord(HRRecord hrRecord)
    {
        await _hrRecordRepository.AddHRRecordAsync(hrRecord);
        return Ok();
    }
}