public class FinancialRecord
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Revenue { get; set; }
    public decimal NetIncome { get; set; }
    public decimal OperatingIncome { get; set; }
    public decimal CostOfGoodsSold { get; set; }
    public decimal OperatingExpenses { get; set; }
    public decimal TotalAssets { get; set; }
    public decimal TotalLiabilities { get; set; }
    public decimal TotalEquity { get; set; }
    public decimal CapitalEmployed { get; set; }
    public decimal Depreciation { get; set; }
    public decimal Amortization { get; set; }
    public decimal Cash { get; set; }
    public decimal Inventory { get; set; }
    public decimal AccountsReceivable { get; set; }
    public decimal AccountsPayable { get; set; }
    public decimal InterestExpense { get; set; }
    public decimal TaxExpense { get; set; }
    public decimal EnergyConsumption { get; set; }
}