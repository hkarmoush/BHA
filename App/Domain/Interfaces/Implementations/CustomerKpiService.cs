using AutoMapper;

public class CustomerKpiService : ICustomerKpiService
{
    private readonly ICustomerRecordRepository _customerRecordRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CustomerKpiService> _logger;

    public CustomerKpiService(ICustomerRecordRepository customerRecordRepository, IMapper mapper, ILogger<CustomerKpiService> logger)
    {
        _customerRecordRepository = customerRecordRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<KpiResultDto> CalculateCustomerSatisfactionAsync()
    {
        var customerRecords = await _customerRecordRepository.GetAllAsync();
        var value = customerRecords.Any() ? (decimal)customerRecords.Average(r => r.CustomerSatisfactionScore) : 0;

        return new KpiResultDto
        {
            Name = "Customer Satisfaction Score",
            Description = "Measures the average satisfaction score of customers.",
            Formula = "Average(Customer Satisfaction Scores)",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateCustomerRetentionRateAsync()
    {
        var customerRecords = await _customerRecordRepository.GetAllAsync();
        var retainedCustomers = customerRecords.Count(r => r.IsRetained);
        var totalCustomers = customerRecords.Select(r => r.CustomerId).Distinct().Count();

        var value = totalCustomers == 0 ? 0 : (decimal)retainedCustomers / totalCustomers * 100;

        return new KpiResultDto
        {
            Name = "Customer Retention Rate",
            Description = "Measures the percentage of retained customers.",
            Formula = "Retained Customers / Total Customers * 100",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateCustomerAcquisitionCostAsync()
    {
        var customerRecords = await _customerRecordRepository.GetAllAsync();
        var value = customerRecords.Any() ? (decimal)customerRecords.Average(r => r.AcquisitionCost) : 0;

        return new KpiResultDto
        {
            Name = "Customer Acquisition Cost",
            Description = "Measures the cost of acquiring a new customer.",
            Formula = "Average(Customer Acquisition Costs)",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateCustomerLifetimeValueAsync()
    {
        var customerRecords = await _customerRecordRepository.GetAllAsync();
        var value = customerRecords.Any() ? (decimal)customerRecords.Average(r => r.CustomerLifetimeValue) : 0;

        return new KpiResultDto
        {
            Name = "Customer Lifetime Value",
            Description = "Measures the total value a customer brings over their lifetime.",
            Formula = "Average(Customer Lifetime Values)",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateCustomerProfitabilityAsync()
    {
        var customerRecords = await _customerRecordRepository.GetAllAsync();
        var value = customerRecords.Any() ? (decimal)customerRecords.Average(r => r.CustomerProfit) : 0;

        return new KpiResultDto
        {
            Name = "Customer Profitability",
            Description = "Measures the profitability of customers.",
            Formula = "Average(Customer Profits)",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateNetPromoterScoreAsync()
    {
        var customerRecords = await _customerRecordRepository.GetAllAsync();
        var value = customerRecords.Any() ? (decimal)customerRecords.Average(r => r.NetPromoterScore) : 0;

        return new KpiResultDto
        {
            Name = "Net Promoter Score",
            Description = "Measures customer loyalty and satisfaction.",
            Formula = "Average(Net Promoter Scores)",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateCustomerTurnoverRateAsync()
    {
        var customerRecords = await _customerRecordRepository.GetAllAsync();
        var lostCustomers = customerRecords.Count(r => r.IsLost);
        var totalCustomers = customerRecords.Select(r => r.CustomerId).Distinct().Count();

        var value = totalCustomers == 0 ? 0 : (decimal)lostCustomers / totalCustomers * 100;

        return new KpiResultDto
        {
            Name = "Customer Turnover Rate",
            Description = "Measures the rate at which customers are lost.",
            Formula = "Lost Customers / Total Customers * 100",
            Value = value
        };
    }

    public async Task<KpiResultDto> CalculateCustomerEffortScoreAsync()
    {
        var customerRecords = await _customerRecordRepository.GetAllAsync();
        var value = customerRecords.Any() ? (decimal)customerRecords.Average(r => r.CustomerEffortScore) : 0;

        return new KpiResultDto
        {
            Name = "Customer Effort Score",
            Description = "Measures the effort required by customers to interact with the company.",
            Formula = "Average(Customer Effort Scores)",
            Value = value
        };
    }
}
