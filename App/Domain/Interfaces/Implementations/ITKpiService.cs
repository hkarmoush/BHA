using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;

public class ITKpiService : IITKpiService
{
    private readonly IITRecordRepository _itRecordRepository;
    private readonly IFinancialRecordRepository _financialRecordRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<ITKpiService> _logger;

    public ITKpiService(IITRecordRepository itRecordRepository, IFinancialRecordRepository financialRecordRepository, IMapper mapper, ILogger<ITKpiService> logger)
    {
        _itRecordRepository = itRecordRepository;
        _financialRecordRepository = financialRecordRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<KpiResultDto> CalculateITProjectEarnedValueAsync()
    {
        var itRecords = await _itRecordRepository.GetAllAsync();
        var value = itRecords.Sum(r => r.ProjectEarnedValue);

        return new KpiResultDto
        {
            Name = "IT Project Earned Value",
            Description = "Measures the earned value of IT projects.",
            Formula = "Sum of Project Earned Value",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateNumberOfITSecurityBreachesAsync()
    {
        var itRecords = await _itRecordRepository.GetAllAsync();
        var value = itRecords.Sum(r => r.SecurityBreaches);

        return new KpiResultDto
        {
            Name = "Number of IT Security Breaches",
            Description = "Measures the number of IT security breaches.",
            Formula = "Sum of Security Breaches",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateITCostsAsPercentageOfRevenueAsync()
    {
        var itRecords = await _itRecordRepository.GetAllAsync();
        var financialRecords = await _financialRecordRepository.GetFinancialRecordsAsync();

        var totalITCosts = itRecords.Sum(r => r.ITCosts);
        var totalRevenue = financialRecords.Sum(r => r.Revenue);

        var value = totalRevenue == 0 ? 0 : (totalITCosts / totalRevenue) * 100;

        return new KpiResultDto
        {
            Name = "IT Costs as Percentage of Revenue",
            Description = "Measures the percentage of IT costs relative to the total revenue.",
            Formula = "(Total IT Costs / Total Revenue) * 100",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateHelpDeskFirstCallResolutionAsync()
    {
        var itRecords = await _itRecordRepository.GetAllAsync();
        var value = itRecords.Average(r => r.HelpDeskFirstCallResolution);

        return new KpiResultDto
        {
            Name = "Help Desk First Call Resolution",
            Description = "Measures the percentage of help desk tickets resolved on the first call.",
            Formula = "Average(Help Desk First Call Resolution)",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateInternalITServiceSatisfactionScoreAsync()
    {
        var itRecords = await _itRecordRepository.GetAllAsync();
        var value = itRecords.Average(r => r.InternalITServiceSatisfactionScore);

        return new KpiResultDto
        {
            Name = "Internal IT Service Satisfaction Score",
            Description = "Measures the satisfaction score of internal IT services.",
            Formula = "Average(Internal IT Service Satisfaction Score)",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateITProjectCostVarianceAsync()
    {
        var itRecords = await _itRecordRepository.GetAllAsync();
        var value = itRecords.Average(r => r.ProjectCostVariance);

        return new KpiResultDto
        {
            Name = "IT Project Cost Variance",
            Description = "Measures the variance in project costs.",
            Formula = "Average(Project Cost Variance)",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateEnterpriseArchitectureComplianceRatioAsync()
    {
        var itRecords = await _itRecordRepository.GetAllAsync();
        var value = itRecords.Average(r => r.EnterpriseArchitectureComplianceRatio);

        return new KpiResultDto
        {
            Name = "Enterprise Architecture Compliance Ratio",
            Description = "Measures the compliance ratio of enterprise architecture.",
            Formula = "Average(Enterprise Architecture Compliance Ratio)",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateAverageAgeOfITInfrastructureAsync()
    {
        var itRecords = await _itRecordRepository.GetAllAsync();
        var value = itRecords.Average(r => r.AverageAgeOfITInfrastructure);

        return new KpiResultDto
        {
            Name = "Average Age of IT Infrastructure",
            Description = "Measures the average age of IT infrastructure.",
            Formula = "Average(Average Age of IT Infrastructure)",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateIncidentResolutionIndexAsync()
    {
        var itRecords = await _itRecordRepository.GetAllAsync();
        var value = itRecords.Average(r => r.IncidentResolutionIndex);

        return new KpiResultDto
        {
            Name = "Incident Resolution Index",
            Description = "Measures the index of incident resolutions.",
            Formula = "Average(Incident Resolution Index)",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateWebsiteNonAvailabilityAsync()
    {
        var itRecords = await _itRecordRepository.GetAllAsync();
        var value = itRecords.Average(r => r.WebsiteNonAvailability);

        return new KpiResultDto
        {
            Name = "Website Non-Availability",
            Description = "Measures the average time the website is not available.",
            Formula = "Average(Website Non-Availability)",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateITProjectScheduleVarianceAsync()
    {
        var itRecords = await _itRecordRepository.GetAllAsync();
        var value = itRecords.Average(r => r.ProjectScheduleVariance);

        return new KpiResultDto
        {
            Name = "IT Project Schedule Variance",
            Description = "Measures the variance in project schedules.",
            Formula = "Average(Project Schedule Variance)",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateITMaintenanceRatioAsync()
    {
        var itRecords = await _itRecordRepository.GetAllAsync();
        var value = itRecords.Average(r => r.ITMaintenanceRatio);

        return new KpiResultDto
        {
            Name = "IT Maintenance Ratio",
            Description = "Measures the ratio of IT maintenance costs.",
            Formula = "Average(IT Maintenance Ratio)",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateAverageAgeOfSoftwareAsync()
    {
        var itRecords = await _itRecordRepository.GetAllAsync();
        var value = itRecords.Average(r => r.AverageAgeOfSoftware);

        return new KpiResultDto
        {
            Name = "Average Age of Software",
            Description = "Measures the average age of software.",
            Formula = "Average(Average Age of Software)",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateSystemDowntimeAsync()
    {
        var itRecords = await _itRecordRepository.GetAllAsync();
        var value = itRecords.Average(r => r.SystemDowntime);

        return new KpiResultDto
        {
            Name = "System Downtime",
            Description = "Measures the average system downtime.",
            Formula = "Average(System Downtime)",
            Value = value
        };
    }
}
