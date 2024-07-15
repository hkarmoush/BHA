using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ITRecordController : ControllerBase
{
    private readonly IITRecordService _itRecordService;

    public ITRecordController(IITRecordService itRecordService)
    {
        _itRecordService = itRecordService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<ITRecordDto>>> GetAll()
    {
        var itRecords = await _itRecordService.GetAllAsync();
        return Ok(itRecords);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<ITRecordDto>> GetById(Guid id)
    {
        var itRecord = await _itRecordService.GetByIdAsync(id);
        if (itRecord == null)
        {
            return NotFound();
        }
        return Ok(itRecord);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult> Add(ITRecordDto itRecordDto)
    {
        await _itRecordService.AddAsync(itRecordDto);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult> Update(Guid id, ITRecordDto itRecordDto)
    {
        if (id != itRecordDto.Id)
        {
            return BadRequest();
        }

        await _itRecordService.UpdateAsync(itRecordDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _itRecordService.DeleteAsync(id);
        return Ok();
    }
}
