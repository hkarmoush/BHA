using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CustomerKpiService : ICustomerKpiService
{
    private readonly ICustomerService _customerService;

    public CustomerKpiService(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    // Customer Perspective KPIs

    public async Task<decimal> CalculateCustomerSatisfactionAsync()
    {
        var customers = await _customerService.GetCustomersAsync();
        return customers.Average(cr => cr.CustomerSatisfactionScore);
    }

    public async Task<decimal> CalculateCustomerRetentionRateAsync()
    {
        var customers = await _customerService.GetCustomersAsync();
        var retainedCustomers = customers.Count(cr => cr.CustomerLifetimeValue > 0);
        return customers.Count() == 0 ? 0 : (decimal)retainedCustomers / customers.Count() * 100;
    }

    public async Task<decimal> CalculateCustomerAcquisitionCostAsync()
    {
        var customers = await _customerService.GetCustomersAsync();
        var totalAcquisitionCost = customers.Sum(cr => cr.AcquisitionCost);
        var totalNewCustomers = customers.Count(cr => cr.AcquisitionCost > 0);
        return totalNewCustomers == 0 ? 0 : totalAcquisitionCost / totalNewCustomers;
    }

    public async Task<decimal> CalculateCustomerLifetimeValueAsync()
    {
        var customers = await _customerService.GetCustomersAsync();
        return customers.Sum(cr => cr.CustomerLifetimeValue);
    }

    public async Task<decimal> CalculateCustomerProfitabilityAsync()
    {
        var customers = await _customerService.GetCustomersAsync();
        var totalProfit = customers.Sum(cr => cr.CustomerLifetimeValue - cr.AcquisitionCost);
        var totalRevenue = customers.Sum(cr => cr.CustomerLifetimeValue);
        return totalRevenue == 0 ? 0 : totalProfit / totalRevenue * 100;
    }

    public async Task<decimal> CalculateNetPromoterScoreAsync()
    {
        var customers = await _customerService.GetCustomersAsync();
        var promoters = customers.Count(cr => cr.NetPromoterScore >= 9);
        var detractors = customers.Count(cr => cr.NetPromoterScore <= 6);
        return customers.Count() == 0 ? 0 : (decimal)(promoters - detractors) / customers.Count() * 100;
    }

    public async Task<decimal> CalculateCustomerTurnoverRateAsync()
    {
        var customers = await _customerService.GetCustomersAsync();
        var lostCustomers = customers.Count(cr => cr.CustomerLifetimeValue == 0);
        return customers.Count() == 0 ? 0 : (decimal)lostCustomers / customers.Count() * 100;
    }

    public async Task<decimal> CalculateCustomerEffortScoreAsync()
    {
        var customers = await _customerService.GetCustomersAsync();
        return customers.Average(cr => cr.CustomerSatisfactionScore);
    }
}
