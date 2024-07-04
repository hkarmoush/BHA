public class CustomerRecord
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public decimal CustomerSatisfactionScore { get; set; }
    public bool IsRetained { get; set; }
    public decimal AcquisitionCost { get; set; }
    public bool IsNewCustomer { get; set; }
    public decimal CustomerLifetimeValue { get; set; }
    public decimal CustomerProfit { get; set; }
    public decimal CustomerRevenue { get; set; }
    public int NetPromoterScore { get; set; }
    public bool IsLost { get; set; }
    public decimal CustomerEffortScore { get; set; }
}