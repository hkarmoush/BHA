using AutoMapper;

public class HRRecordService : IHRRecordService
{
    private readonly IHRRecordRepository _hrRecordRepository;
    private readonly IMapper _mapper;

    public HRRecordService(IHRRecordRepository hrRecordRepository, IMapper mapper)
    {
        _hrRecordRepository = hrRecordRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<HRRecordDto>> GetHRRecordsAsync()
    {
        var hrRecords = await _hrRecordRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<HRRecordDto>>(hrRecords);
    }

    public async Task<HRRecordDto> GetHRRecordByIdAsync(Guid id)
    {
        var hrRecord = await _hrRecordRepository.GetByIdAsync(id);
        return _mapper.Map<HRRecordDto>(hrRecord);
    }

    public async Task AddHRRecordAsync(HRRecordDto hrRecordDto)
    {
        var hrRecord = _mapper.Map<HRRecord>(hrRecordDto);
        await _hrRecordRepository.AddAsync(hrRecord);
    }

    public async Task UpdateHRRecordAsync(HRRecordDto hrRecordDto)
    {
        var hrRecord = _mapper.Map<HRRecord>(hrRecordDto);
        await _hrRecordRepository.UpdateAsync(hrRecord);
    }

    public async Task DeleteHRRecordAsync(Guid id)
    {
        await _hrRecordRepository.DeleteAsync(id);
    }
}
