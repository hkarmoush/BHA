using AutoMapper;

public class HRKpiService : IHRKpiService
{
    private readonly IHRRecordRepository _hrRecordRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<HRKpiService> _logger;

    public HRKpiService(IHRRecordRepository hrRecordRepository, IMapper mapper, ILogger<HRKpiService> logger)
    {
        _hrRecordRepository = hrRecordRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<KpiResultDto> CalculateEmployeeTurnoverRateAsync()
    {
        var hrRecords = await _hrRecordRepository.GetAllAsync();
        var terminations = hrRecords.Count(r => r.EventType == "Termination" || r.EventType == "Resignation");
        var hires = hrRecords.Count(r => r.EventType == "Hire");

        _logger.LogInformation($"Terminations: {terminations}, Hires: {hires}");

        var value = hires == 0 ? 0 : (decimal)terminations / hires * 100;

        return new KpiResultDto
        {
            Name = "Employee Turnover Rate",
            Description = "Measures the rate at which employees leave the company.",
            Formula = "Terminations / Hires * 100",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateEmployeeSatisfactionIndexAsync()
    {
        var hrRecords = await _hrRecordRepository.GetAllAsync();
        var satisfactionScores = hrRecords.Select(r => r.SatisfactionScore);

        _logger.LogInformation($"Satisfaction Scores: {string.Join(", ", satisfactionScores)}");

        var value = !satisfactionScores.Any() ? 0 : (decimal)satisfactionScores.Average();

        return new KpiResultDto
        {
            Name = "Employee Satisfaction Index",
            Description = "Measures the average satisfaction score of employees.",
            Formula = "Average(Satisfaction Scores)",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateTimeToHireAsync()
    {
        var hrRecords = await _hrRecordRepository.GetAllAsync();
        var hireRecords = hrRecords.Where(r => r.EventType == "Hire");

        _logger.LogInformation($"Hire Records Count: {hireRecords.Count()}");

        var value = hireRecords.Any() ? 30 : 0; // Example placeholder value

        return new KpiResultDto
        {
            Name = "Time to Hire",
            Description = "Measures the average time to fill a vacant position.",
            Formula = "Time to fill / Number of hires",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateDiversityAndInclusionMetricsAsync()
    {
        var hrRecords = await _hrRecordRepository.GetAllAsync();
        var diverseEmployees = hrRecords.Count(r => r.IsDiverse);
        var totalEmployees = hrRecords.Select(r => r.EmployeeId).Distinct().Count();

        _logger.LogInformation($"Diverse Employees: {diverseEmployees}, Total Employees: {totalEmployees}");

        var value = totalEmployees == 0 ? 0 : (decimal)diverseEmployees / totalEmployees * 100;

        return new KpiResultDto
        {
            Name = "Diversity and Inclusion Metrics",
            Description = "Measures the percentage of diverse employees in the company.",
            Formula = "Diverse Employees / Total Employees * 100",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateTrainingHoursPerEmployeeAsync()
    {
        var hrRecords = await _hrRecordRepository.GetAllAsync();
        var totalTrainingHours = hrRecords.Sum(r => r.TrainingHours);
        var totalEmployees = hrRecords.Select(r => r.EmployeeId).Distinct().Count();

        _logger.LogInformation($"Total Training Hours: {totalTrainingHours}, Total Employees: {totalEmployees}");

        var value = totalEmployees == 0 ? 0 : (decimal)totalTrainingHours / totalEmployees;

        return new KpiResultDto
        {
            Name = "Training Hours per Employee",
            Description = "Measures the average number of training hours per employee.",
            Formula = "Total Training Hours / Total Employees",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateAbsenteeismRateAsync()
    {
        var hrRecords = await _hrRecordRepository.GetAllAsync();
        var totalAbsenteeismDays = hrRecords.Sum(r => r.AbsenteeismDays);
        var totalEmployees = hrRecords.Select(r => r.EmployeeId).Distinct().Count();

        _logger.LogInformation($"Total Absenteeism Days: {totalAbsenteeismDays}, Total Employees: {totalEmployees}");

        var value = totalEmployees == 0 ? 0 : (decimal)totalAbsenteeismDays / totalEmployees;

        return new KpiResultDto
        {
            Name = "Absenteeism Rate",
            Description = "Measures the average absenteeism rate among employees.",
            Formula = "Total Absenteeism Days / Total Employees",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateEmployeeProductivityRateAsync()
    {
        var hrRecords = await _hrRecordRepository.GetAllAsync();
        var productivityScores = hrRecords.Select(r => r.ProductivityScore);

        _logger.LogInformation($"Productivity Scores: {string.Join(", ", productivityScores)}");

        var value = !productivityScores.Any() ? 0 : (decimal)productivityScores.Average();

        return new KpiResultDto
        {
            Name = "Employee Productivity Rate",
            Description = "Measures the average productivity score of employees.",
            Formula = "Average(Productivity Scores)",
            Value = value
        };
    }
}