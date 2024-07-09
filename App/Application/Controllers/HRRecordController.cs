using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HRRecordController : ControllerBase
{
    private readonly IHRRecordService _hrRecordService;

    public HRRecordController(IHRRecordService hrRecordService)
    {
        _hrRecordService = hrRecordService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<HRRecordDto>>> GetHRRecords()
    {
        var hrRecords = await _hrRecordService.GetHRRecordsAsync();
        return Ok(hrRecords);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<HRRecordDto>> GetHRRecordById(Guid id)
    {
        var hrRecord = await _hrRecordService.GetHRRecordByIdAsync(id);
        if (hrRecord == null)
        {
            return NotFound();
        }
        return Ok(hrRecord);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult> AddHRRecord(HRRecordDto hrRecordDto)
    {
        await _hrRecordService.AddHRRecordAsync(hrRecordDto);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult> UpdateHRRecord(Guid id, HRRecordDto hrRecordDto)
    {
        if (id != hrRecordDto.Id)
        {
            return BadRequest();
        }

        await _hrRecordService.UpdateHRRecordAsync(hrRecordDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult> DeleteHRRecord(Guid id)
    {
        await _hrRecordService.DeleteHRRecordAsync(id);
        return Ok();
    }
}
