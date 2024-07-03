using Infrastructure.Data;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.EnsureCreated();

        // Check if SalesRecords have already been seeded
        if (!context.SalesRecords.Any())
        {
            SeedSalesRecords(context);
        }

        // Check if FinancialRecords have already been seeded
        if (!context.FinancialRecords.Any())
        {
            SeedFinancialRecords(context);
        }

        // Check if HRRecords have already been seeded
        if (!context.HRRecords.Any())
        {
            SeedHRRecords(context);
        }

        // Check if KPIs have already been seeded
        if (!context.Kpis.Any())
        {
            SeedKpis(context);
        }

        context.SaveChanges();
    }

    private static void SeedSalesRecords(AppDbContext context)
    {
        var salesRecords = new[]
        {
            new SalesRecord { Id = Guid.NewGuid(), Date = new DateTime(2024, 1, 1), Amount = 1000, CustomerId = Guid.NewGuid(), Product = "Product A" },
            new SalesRecord { Id = Guid.NewGuid(), Date = new DateTime(2024, 1, 15), Amount = 1500, CustomerId = Guid.NewGuid(), Product = "Product B" },
            new SalesRecord { Id = Guid.NewGuid(), Date = new DateTime(2024, 2, 1), Amount = 2000, CustomerId = Guid.NewGuid(), Product = "Product C" },
            new SalesRecord { Id = Guid.NewGuid(), Date = new DateTime(2024, 2, 15), Amount = 2500, CustomerId = Guid.NewGuid(), Product = "Product D" },
            new SalesRecord { Id = Guid.NewGuid(), Date = new DateTime(2024, 3, 1), Amount = 3000, CustomerId = Guid.NewGuid(), Product = "Product E" },
            // Add more sample data as needed
        };

        foreach (var record in salesRecords)
        {
            context.SalesRecords.Add(record);
        }
    }

    private static void SeedFinancialRecords(AppDbContext context)
    {
        var financialRecords = new[]
        {
            new FinancialRecord { Id = Guid.NewGuid(), Date = new DateTime(2024, 1, 1), Revenue = 10000, Expense = 7000 },
            new FinancialRecord { Id = Guid.NewGuid(), Date = new DateTime(2024, 1, 15), Revenue = 15000, Expense = 9000 },
            new FinancialRecord { Id = Guid.NewGuid(), Date = new DateTime(2024, 2, 1), Revenue = 20000, Expense = 12000 },
            new FinancialRecord { Id = Guid.NewGuid(), Date = new DateTime(2024, 2, 15), Revenue = 25000, Expense = 15000 },
            new FinancialRecord { Id = Guid.NewGuid(), Date = new DateTime(2024, 3, 1), Revenue = 30000, Expense = 18000 },
            // Add more sample data as needed
        };

        foreach (var record in financialRecords)
        {
            context.FinancialRecords.Add(record);
        }
    }

    private static void SeedHRRecords(AppDbContext context)
    {
        var hrRecords = new[]
        {
            new HRRecord { Id = Guid.NewGuid(), Date = new DateTime(2024, 1, 1), EmployeeId = Guid.NewGuid(), EventType = "Hire", SatisfactionScore = 85 },
            new HRRecord { Id = Guid.NewGuid(), Date = new DateTime(2024, 1, 15), EmployeeId = Guid.NewGuid(), EventType = "Promotion", SatisfactionScore = 90 },
            new HRRecord { Id = Guid.NewGuid(), Date = new DateTime(2024, 2, 1), EmployeeId = Guid.NewGuid(), EventType = "Resignation", SatisfactionScore = 60 },
            new HRRecord { Id = Guid.NewGuid(), Date = new DateTime(2024, 2, 15), EmployeeId = Guid.NewGuid(), EventType = "Hire", SatisfactionScore = 80 },
            new HRRecord { Id = Guid.NewGuid(), Date = new DateTime(2024, 3, 1), EmployeeId = Guid.NewGuid(), EventType = "Termination", SatisfactionScore = 70 },
            // Add more sample data as needed
        };

        foreach (var record in hrRecords)
        {
            context.HRRecords.Add(record);
        }
    }

    private static void SeedKpis(AppDbContext context)
    {
        var kpis = new Kpi[]
        {
            new Kpi { Id = Guid.NewGuid(), Name = "Total Sales", Description = "Measures the total revenue generated from sales.", Value = "0", Role = Role.SalesDirector },
            new Kpi { Id = Guid.NewGuid(), Name = "Sales Growth", Description = "Measures the increase in sales over a specific period.", Value = "0%", Role = Role.SalesDirector },
            new Kpi { Id = Guid.NewGuid(), Name = "Customer Acquisition Cost (CAC)", Description = "Measures the cost associated with acquiring a new customer.", Value = "$0", Role = Role.SalesDirector },
            new Kpi { Id = Guid.NewGuid(), Name = "Average Deal Size", Description = "Measures the average revenue per deal.", Value = "$0", Role = Role.SalesDirector },
            new Kpi { Id = Guid.NewGuid(), Name = "Net Profit Margin", Description = "Profit margin after all expenses.", Value = "0%", Role = Role.FinancialOfficer },
            new Kpi { Id = Guid.NewGuid(), Name = "Gross Profit Margin", Description = "Difference between revenue and cost of goods sold.", Value = "0%", Role = Role.FinancialOfficer },
            new Kpi { Id = Guid.NewGuid(), Name = "Operating Cash Flow", Description = "Cash generated from operations.", Value = "$0", Role = Role.FinancialOfficer },
            new Kpi { Id = Guid.NewGuid(), Name = "Return on Assets (ROA)", Description = "Efficiency in using assets to generate profit.", Value = "0%", Role = Role.FinancialOfficer },
            new Kpi { Id = Guid.NewGuid(), Name = "Revenue", Description = "Total income generated by the company.", Value = "$0", Role = Role.CFO },
            new Kpi { Id = Guid.NewGuid(), Name = "Earnings Before Interest and Taxes (EBIT)", Description = "Profitability.", Value = "$0", Role = Role.CFO },
            new Kpi { Id = Guid.NewGuid(), Name = "Earnings Before Interest, Taxes, Depreciation, and Amortization (EBITDA)", Description = "Overall financial performance.", Value = "$0", Role = Role.CFO },
            new Kpi { Id = Guid.NewGuid(), Name = "Net Profit", Description = "Profit after all expenses.", Value = "$0", Role = Role.CFO },
            new Kpi { Id = Guid.NewGuid(), Name = "Employee Turnover Rate", Description = "Rate at which employees leave the company.", Value = "0%", Role = Role.HR },
            new Kpi { Id = Guid.NewGuid(), Name = "Employee Satisfaction Index", Description = "Employee satisfaction and engagement.", Value = "0%", Role = Role.HR },
            new Kpi { Id = Guid.NewGuid(), Name = "Time to Hire", Description = "Average time to fill a vacant position.", Value = "0 days", Role = Role.HR },
            new Kpi { Id = Guid.NewGuid(), Name = "Diversity and Inclusion Metrics", Description = "Diversity and inclusiveness in the workplace.", Value = "0%", Role = Role.HR },
            // Add more KPIs as needed
        };

        foreach (var kpi in kpis)
        {
            context.Kpis.Add(kpi);
        }
    }
}
