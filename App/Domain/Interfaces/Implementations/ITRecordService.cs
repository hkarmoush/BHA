using AutoMapper;

public class ITRecordService : IITRecordService
{
    private readonly IITRecordRepository _itRecordRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<ITRecordService> _logger;

    public ITRecordService(IITRecordRepository itRecordRepository, IMapper mapper, ILogger<ITRecordService> logger)
    {
        _itRecordRepository = itRecordRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<ITRecordDto>> GetAllAsync()
    {
        var itRecords = await _itRecordRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ITRecordDto>>(itRecords);
    }

    public async Task<ITRecordDto> GetByIdAsync(Guid id)
    {
        var itRecord = await _itRecordRepository.GetByIdAsync(id);
        return _mapper.Map<ITRecordDto>(itRecord);
    }

    public async Task AddAsync(ITRecordDto itRecordDto)
    {
        var itRecord = _mapper.Map<ITRecord>(itRecordDto);
        await _itRecordRepository.AddAsync(itRecord);
    }

    public async Task UpdateAsync(ITRecordDto itRecordDto)
    {
        var itRecord = _mapper.Map<ITRecord>(itRecordDto);
        await _itRecordRepository.UpdateAsync(itRecord);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _itRecordRepository.DeleteAsync(id);
    }
}