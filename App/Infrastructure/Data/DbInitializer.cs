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

        // Check if Customers have already been seeded
        if (!context.Customers.Any())
        {
            SeedCustomers(context);
        }

        // Check if CustomerRecords have already been seeded
        if (!context.CustomerRecords.Any())
        {
            SeedCustomerRecords(context);
        }
        if (!context.Users.Any(u => u.Role == Role.SuperAdmin))
        {
            SeedSuperAdmin(context);
        }
        if (!context.Employees.Any())
        {
            SeedEmployees(context);
        }
        if (!context.HRRecords.Any())
        {
            SeedHRRecords(context);
        }
        if (!context.ITRecords.Any())
        {
            SeedITRecords(context);
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
        var random = new Random();
        var financialRecords = new List<FinancialRecord>();

        for (int year = 2023; year <= 2024; year++)
        {
            for (int month = 1; month <= 12; month++)
            {
                financialRecords.Add(new FinancialRecord
                {
                    Id = Guid.NewGuid(),
                    Date = new DateTime(year, month, 1),
                    Revenue = random.Next(80000, 150000),
                    NetIncome = random.Next(10000, 30000),
                    OperatingIncome = random.Next(15000, 35000),
                    CostOfGoodsSold = random.Next(30000, 50000),
                    OperatingExpenses = random.Next(10000, 20000),
                    TotalAssets = random.Next(400000, 600000),
                    TotalLiabilities = random.Next(150000, 300000),
                    TotalEquity = random.Next(250000, 400000),
                    CapitalEmployed = random.Next(300000, 450000),
                    Depreciation = random.Next(4000, 7000),
                    Amortization = random.Next(2000, 5000),
                    Cash = random.Next(90000, 120000),
                    Inventory = random.Next(15000, 30000),
                    AccountsReceivable = random.Next(10000, 20000),
                    AccountsPayable = random.Next(8000, 15000),
                    InterestExpense = random.Next(1500, 2500),
                    TaxExpense = random.Next(2500, 4000),
                    EnergyConsumption = random.Next(4500, 6000)
                });
            }
        }

        foreach (var record in financialRecords)
        {
            context.FinancialRecords.Add(record);
        }
    }
    private static void SeedEmployees(AppDbContext context)
    {
        var employees = new[]
        {
            new Employee { Id = Guid.NewGuid(), Name = "John Doe", Department = "HR", Position = "HR Manager", HireDate = new DateTime(2023, 1, 1) },
            new Employee { Id = Guid.NewGuid(), Name = "Jane Smith", Department = "Sales", Position = "Sales Director", HireDate = new DateTime(2023, 2, 1) },
            new Employee { Id = Guid.NewGuid(), Name = "Alice Johnson", Department = "Finance", Position = "Financial Officer", HireDate = new DateTime(2023, 3, 1) },
            // Add more sample employees as needed
        };

        context.Employees.AddRange(employees);
        context.SaveChanges();
    }

    private static void SeedHRRecords(AppDbContext context)
    {
        var employees = context.Employees.ToList();
        var random = new Random();
        var hrRecords = new List<HRRecord>();

        for (int year = 2023; year <= 2024; year++)
        {
            for (int month = 1; month <= 12; month++)
            {
                // foreach (var employee in employees)
                // {
                hrRecords.Add(new HRRecord
                {
                    Id = Guid.NewGuid(),
                    Date = new DateTime(year, month, 1),
                    EmployeeId = Guid.NewGuid(),
                    EventType = "Hire",
                    SatisfactionScore = random.Next(60, 100),
                    TrainingHours = random.Next(5, 25),
                    AbsenteeismDays = random.Next(0, 5),
                    ProductivityScore = random.Next(5, 10),
                    IsDiverse = random.Next(0, 2) == 1
                });
                // }
            }
        }

        context.HRRecords.AddRange(hrRecords);
        context.SaveChanges();
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

    private static void SeedCustomers(AppDbContext context)
    {
        var customers = new[]
        {
            new Customer { Id = Guid.NewGuid(), Name = "Customer A", Email = "customerA@example.com", AcquisitionCost = 100, CustomerSatisfactionScore = 85, CustomerLifetimeValue = 5000, NetPromoterScore = 9 },
            new Customer { Id = Guid.NewGuid(), Name = "Customer B", Email = "customerB@example.com", AcquisitionCost = 150, CustomerSatisfactionScore = 88, CustomerLifetimeValue = 7000, NetPromoterScore = 8 },
            new Customer { Id = Guid.NewGuid(), Name = "Customer C", Email = "customerC@example.com", AcquisitionCost = 200, CustomerSatisfactionScore = 90, CustomerLifetimeValue = 9000, NetPromoterScore = 10 },
        };

        context.Customers.AddRange(customers);
    }

    private static void SeedCustomerRecords(AppDbContext context)
    {
        var random = new Random();
        var customerRecords = new List<CustomerRecord>();
        var customerIds = context.Customers.Select(c => c.Id).ToList();

        for (int year = 2023; year <= 2024; year++)
        {
            for (int month = 1; month <= 12; month++)
            {
                foreach (var customerId in customerIds)
                {
                    customerRecords.Add(new CustomerRecord
                    {
                        Id = Guid.NewGuid(),
                        Date = new DateTime(year, month, 1),
                        CustomerId = customerId,
                        CustomerSatisfactionScore = random.Next(60, 100),
                        IsRetained = random.Next(0, 2) == 1,
                        AcquisitionCost = random.Next(100, 200),
                        IsNewCustomer = random.Next(0, 2) == 1,
                        CustomerLifetimeValue = random.Next(5000, 10000),
                        CustomerProfit = random.Next(4000, 9000),
                        CustomerRevenue = random.Next(5000, 10000),
                        NetPromoterScore = random.Next(0, 10),
                        IsLost = random.Next(0, 2) == 1,
                        CustomerEffortScore = random.Next(0, 5)
                    });
                }
            }
        }

        context.CustomerRecords.AddRange(customerRecords);
    }

    private static void SeedSuperAdmin(AppDbContext context)
    {
        var superAdmin = new User
        {
            Id = Guid.NewGuid(),
            Name = "Super Admin",
            Email = "superadmin@example.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Apple@123123"),
            Role = Role.SuperAdmin,
            AccessToken = string.Empty,
            RefreshToken = string.Empty
        };

        context.Users.Add(superAdmin);
    }

    private static void SeedITRecords(AppDbContext context)
    {
        var random = new Random();
        var itRecords = new List<ITRecord>();

        for (int year = 2023; year <= 2024; year++)
        {
            for (int month = 1; month <= 12; month++)
            {
                itRecords.Add(new ITRecord
                {
                    Id = Guid.NewGuid(),
                    Date = new DateTime(year, month, 1),
                    ProjectEarnedValue = random.Next(1000, 10000),
                    SecurityBreaches = random.Next(0, 10),
                    ITCosts = random.Next(10000, 50000),
                    HelpDeskFirstCallResolution = random.Next(70, 100),
                    InternalITServiceSatisfactionScore = random.Next(60, 100),
                    ProjectCostVariance = random.Next(-5000, 5000),
                    EnterpriseArchitectureComplianceRatio = random.Next(80, 100),
                    AverageAgeOfITInfrastructure = random.Next(1, 10),
                    IncidentResolutionIndex = random.Next(70, 100),
                    WebsiteNonAvailability = random.Next(0, 10),
                    ProjectScheduleVariance = random.Next(-5, 5),
                    ITMaintenanceRatio = random.Next(5, 20),
                    AverageAgeOfSoftware = random.Next(1, 5),
                    SystemDowntime = random.Next(0, 10)
                });
            }
        }
        context.ITRecords.AddRange(itRecords);
        context.SaveChanges();
    }
}
