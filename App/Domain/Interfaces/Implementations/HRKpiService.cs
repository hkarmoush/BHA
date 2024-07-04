using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;

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

    public async Task<decimal> CalculateEmployeeTurnoverRateAsync()
    {
        var hrRecords = await _hrRecordRepository.GetAllAsync();
        var terminations = hrRecords.Count(r => r.EventType == "Termination" || r.EventType == "Resignation");
        var hires = hrRecords.Count(r => r.EventType == "Hire");

        _logger.LogInformation($"Terminations: {terminations}, Hires: {hires}");

        if (hires == 0) return 0;
        return (decimal)terminations / hires * 100;
    }

    public async Task<decimal> CalculateEmployeeSatisfactionIndexAsync()
    {
        var hrRecords = await _hrRecordRepository.GetAllAsync();
        var satisfactionScores = hrRecords.Select(r => r.SatisfactionScore);

        _logger.LogInformation($"Satisfaction Scores: {string.Join(", ", satisfactionScores)}");

        if (!satisfactionScores.Any()) return 0;
        return (decimal)satisfactionScores.Average();
    }

    public async Task<decimal> CalculateTimeToHireAsync()
    {
        var hrRecords = await _hrRecordRepository.GetAllAsync();
        var hireRecords = hrRecords.Where(r => r.EventType == "Hire");

        _logger.LogInformation($"Hire Records Count: {hireRecords.Count()}");

        // Assuming you have a way to calculate time to hire
        // For now, let's return a placeholder value
        return hireRecords.Any() ? 30 : 0; // Example placeholder value
    }

    public async Task<decimal> CalculateDiversityAndInclusionMetricsAsync()
    {
        var hrRecords = await _hrRecordRepository.GetAllAsync();
        var diverseEmployees = hrRecords.Count(r => r.IsDiverse);
        var totalEmployees = hrRecords.Select(r => r.EmployeeId).Distinct().Count();

        _logger.LogInformation($"Diverse Employees: {diverseEmployees}, Total Employees: {totalEmployees}");

        if (totalEmployees == 0) return 0;
        return (decimal)diverseEmployees / totalEmployees * 100;
    }

    public async Task<decimal> CalculateTrainingHoursPerEmployeeAsync()
    {
        var hrRecords = await _hrRecordRepository.GetAllAsync();
        var totalTrainingHours = hrRecords.Sum(r => r.TrainingHours);
        var totalEmployees = hrRecords.Select(r => r.EmployeeId).Distinct().Count();

        _logger.LogInformation($"Total Training Hours: {totalTrainingHours}, Total Employees: {totalEmployees}");

        if (totalEmployees == 0) return 0;
        return (decimal)totalTrainingHours / totalEmployees;
    }

    public async Task<decimal> CalculateAbsenteeismRateAsync()
    {
        var hrRecords = await _hrRecordRepository.GetAllAsync();
        var totalAbsenteeismDays = hrRecords.Sum(r => r.AbsenteeismDays);
        var totalEmployees = hrRecords.Select(r => r.EmployeeId).Distinct().Count();

        _logger.LogInformation($"Total Absenteeism Days: {totalAbsenteeismDays}, Total Employees: {totalEmployees}");

        if (totalEmployees == 0) return 0;
        return (decimal)totalAbsenteeismDays / totalEmployees;
    }

    public async Task<decimal> CalculateEmployeeProductivityRateAsync()
    {
        var hrRecords = await _hrRecordRepository.GetAllAsync();
        var productivityScores = hrRecords.Select(r => r.ProductivityScore);

        _logger.LogInformation($"Productivity Scores: {string.Join(", ", productivityScores)}");

        if (!productivityScores.Any()) return 0;
        return (decimal)productivityScores.Average();
    }
}
