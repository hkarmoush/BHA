public class KpiService : IKpiService
{
    private readonly IKpiRepository _kpiRepository;
    private readonly ISalesRecordRepository _salesRecordRepository;
    private readonly IFinancialRecordRepository _financialRecordRepository;
    private readonly IHRRecordRepository _hrRecordRepository;

    public KpiService(IKpiRepository kpiRepository, ISalesRecordRepository salesRecordRepository,
                      IFinancialRecordRepository financialRecordRepository, IHRRecordRepository hrRecordRepository)
    {
        _kpiRepository = kpiRepository;
        _salesRecordRepository = salesRecordRepository;
        _financialRecordRepository = financialRecordRepository;
        _hrRecordRepository = hrRecordRepository;
    }

    public async Task<IEnumerable<KpiDto>> GetKpisForUserRoleAsync(Role role)
    {
        var kpis = await _kpiRepository.GetKpisByRoleAsync(role);

        foreach (var kpi in kpis)
        {
            if (role == Role.SalesDirector)
            {
                var salesRecords = await _salesRecordRepository.GetSalesRecordsAsync();
                CalculateSalesKpis(kpi, salesRecords);
            }
            else if (role == Role.FinancialOfficer || role == Role.CFO)
            {
                var financialRecords = await _financialRecordRepository.GetFinancialRecordsAsync();
                CalculateFinancialKpis(kpi, financialRecords);
            }
            else if (role == Role.HR)
            {
                var hrRecords = await _hrRecordRepository.GetHRRecordsAsync();
                CalculateHRKpis(kpi, hrRecords);
            }
        }

        return kpis.Select(k => new KpiDto
        {
            Id = k.Id,
            Name = k.Name,
            Description = k.Description,
            Value = k.Value
        });
    }

    public async Task<IEnumerable<KpiDto>> GetAllKpisAsync()
    {
        var kpis = await _kpiRepository.GetAllKpisAsync();

        foreach (var kpi in kpis)
        {
            var salesRecords = await _salesRecordRepository.GetSalesRecordsAsync();
            var financialRecords = await _financialRecordRepository.GetFinancialRecordsAsync();
            var hrRecords = await _hrRecordRepository.GetHRRecordsAsync();

            CalculateSalesKpis(kpi, salesRecords);
            CalculateFinancialKpis(kpi, financialRecords);
            CalculateHRKpis(kpi, hrRecords);
        }

        return kpis.Select(k => new KpiDto
        {
            Id = k.Id,
            Name = k.Name,
            Description = k.Description,
            Value = k.Value
        });
    }

    private void CalculateSalesKpis(Kpi kpi, IEnumerable<SalesRecord> salesRecords)
    {
        if (kpi.Name == "Total Sales")
        {
            kpi.Value = salesRecords.Sum(sr => sr.Amount).ToString("C");
        }
        else if (kpi.Name == "Sales Growth")
        {
            kpi.Value = CalculateSalesGrowth(salesRecords).ToString("P");
        }
        else if (kpi.Name == "Customer Acquisition Cost (CAC)")
        {
            kpi.Value = CalculateCustomerAcquisitionCost(salesRecords).ToString("C");
        }
        else if (kpi.Name == "Average Deal Size")
        {
            kpi.Value = CalculateAverageDealSize(salesRecords).ToString("C");
        }
    }

    private decimal CalculateSalesGrowth(IEnumerable<SalesRecord> salesRecords)
    {
        var groupedByMonth = salesRecords
            .GroupBy(sr => new { sr.Date.Year, sr.Date.Month })
            .Select(g => new
            {
                Year = g.Key.Year,
                Month = g.Key.Month,
                TotalSales = g.Sum(sr => sr.Amount)
            })
            .OrderBy(g => g.Year).ThenBy(g => g.Month)
            .ToList();

        if (groupedByMonth.Count < 2)
        {
            return 0;
        }

        var lastMonthSales = groupedByMonth[^1].TotalSales;
        var previousMonthSales = groupedByMonth[^2].TotalSales;

        return previousMonthSales == 0 ? 0 : (lastMonthSales - previousMonthSales) / previousMonthSales;
    }

    private decimal CalculateCustomerAcquisitionCost(IEnumerable<SalesRecord> salesRecords)
    {
        var totalSales = salesRecords.Sum(sr => sr.Amount);
        var numberOfCustomers = salesRecords.Select(sr => sr.CustomerId).Distinct().Count();
        var totalCost = 5000; // Replace this with actual cost data

        return numberOfCustomers == 0 ? 0 : totalCost / numberOfCustomers;
    }

    private decimal CalculateAverageDealSize(IEnumerable<SalesRecord> salesRecords)
    {
        var numberOfDeals = salesRecords.Count();
        var totalSales = salesRecords.Sum(sr => sr.Amount);

        return numberOfDeals == 0 ? 0 : totalSales / numberOfDeals;
    }

    private void CalculateFinancialKpis(Kpi kpi, IEnumerable<FinancialRecord> financialRecords)
    {
        if (kpi.Name == "Net Profit Margin")
        {
            kpi.Value = CalculateNetProfitMargin(financialRecords).ToString("P");
        }
        else if (kpi.Name == "Gross Profit Margin")
        {
            kpi.Value = CalculateGrossProfitMargin(financialRecords).ToString("P");
        }
        else if (kpi.Name == "Operating Cash Flow")
        {
            kpi.Value = CalculateOperatingCashFlow(financialRecords).ToString("C");
        }
        else if (kpi.Name == "Return on Assets (ROA)")
        {
            kpi.Value = CalculateReturnOnAssets(financialRecords).ToString("P");
        }
    }

    private decimal CalculateNetProfitMargin(IEnumerable<FinancialRecord> financialRecords)
    {
        var totalRevenue = financialRecords.Sum(fr => fr.Revenue);
        var totalExpense = financialRecords.Sum(fr => fr.Expense);

        return totalRevenue == 0 ? 0 : (totalRevenue - totalExpense) / totalRevenue;
    }

    private decimal CalculateGrossProfitMargin(IEnumerable<FinancialRecord> financialRecords)
    {
        var totalRevenue = financialRecords.Sum(fr => fr.Revenue);
        var totalExpense = financialRecords.Sum(fr => fr.Expense); // This should be cost of goods sold (COGS)

        return totalRevenue == 0 ? 0 : (totalRevenue - totalExpense) / totalRevenue;
    }

    private decimal CalculateOperatingCashFlow(IEnumerable<FinancialRecord> financialRecords)
    {
        return financialRecords.Sum(fr => fr.Revenue - fr.Expense);
    }

    private decimal CalculateReturnOnAssets(IEnumerable<FinancialRecord> financialRecords)
    {
        var totalRevenue = financialRecords.Sum(fr => fr.Revenue);
        var totalAssets = 50000; // Replace this with actual assets data

        return totalAssets == 0 ? 0 : totalRevenue / totalAssets;
    }

    private void CalculateHRKpis(Kpi kpi, IEnumerable<HRRecord> hrRecords)
    {
        if (kpi.Name == "Employee Turnover Rate")
        {
            kpi.Value = CalculateEmployeeTurnoverRate(hrRecords).ToString("P");
        }
        else if (kpi.Name == "Employee Satisfaction Index")
        {
            kpi.Value = CalculateEmployeeSatisfactionIndex(hrRecords).ToString();
        }
        else if (kpi.Name == "Time to Hire")
        {
            kpi.Value = CalculateTimeToHire(hrRecords).ToString("N0") + " days";
        }
        else if (kpi.Name == "Diversity and Inclusion Metrics")
        {
            kpi.Value = CalculateDiversityAndInclusionMetrics(hrRecords).ToString("P");
        }
    }

    private decimal CalculateEmployeeTurnoverRate(IEnumerable<HRRecord> hrRecords)
    {
        var totalEmployees = hrRecords.Select(hr => hr.EmployeeId).Distinct().Count();
        var employeesLeft = hrRecords.Count(hr => hr.EventType == "Resignation" || hr.EventType == "Termination");

        return totalEmployees == 0 ? 0 : (decimal)employeesLeft / totalEmployees;
    }

    private decimal CalculateEmployeeSatisfactionIndex(IEnumerable<HRRecord> hrRecords)
    {
        var totalEvents = hrRecords.Count();
        var totalSatisfaction = hrRecords.Sum(hr => hr.SatisfactionScore);

        return totalEvents == 0 ? 0 : (decimal)totalSatisfaction / totalEvents;
    }

    private decimal CalculateTimeToHire(IEnumerable<HRRecord> hrRecords)
    {
        var hireEvents = hrRecords.Where(hr => hr.EventType == "Hire").ToList();

        if (hireEvents.Count < 2)
        {
            return 0;
        }

        var totalTime = 0;
        for (int i = 1; i < hireEvents.Count; i++)
        {
            totalTime += (hireEvents[i].Date - hireEvents[i - 1].Date).Days;
        }

        return (decimal)totalTime / (hireEvents.Count - 1);
    }

    private decimal CalculateDiversityAndInclusionMetrics(IEnumerable<HRRecord> hrRecords)
    {
        // Example calculation: Percentage of diverse hires
        var totalHires = hrRecords.Count(hr => hr.EventType == "Hire");
        var diverseHires = hrRecords.Count(hr => hr.EventType == "Hire" && hr.SatisfactionScore >= 80); // Assuming satisfaction score indicates diversity

        return totalHires == 0 ? 0 : (decimal)diverseHires / totalHires;
    }
}
