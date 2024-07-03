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

    private static void SeedKpis(AppDbContext context)
    {
        var kpis = new Kpi[]
        {
            new Kpi { Id = Guid.NewGuid(), Name = "Total Sales", Description = "Measures the total revenue generated from sales.", Value = "0", Role = Role.SalesDirector },
            new Kpi { Id = Guid.NewGuid(), Name = "Sales Growth", Description = "Measures the increase in sales over a specific period.", Value = "0%", Role = Role.SalesDirector },
            new Kpi { Id = Guid.NewGuid(), Name = "Customer Acquisition Cost (CAC)", Description = "Measures the cost associated with acquiring a new customer.", Value = "$0", Role = Role.SalesDirector },
            new Kpi { Id = Guid.NewGuid(), Name = "Average Deal Size", Description = "Measures the average revenue per deal.", Value = "$0", Role = Role.SalesDirector },
            // Add more KPIs as needed
        };

        foreach (var kpi in kpis)
        {
            context.Kpis.Add(kpi);
        }
    }
}
