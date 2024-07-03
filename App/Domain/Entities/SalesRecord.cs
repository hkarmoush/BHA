public class SalesRecord
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public Guid CustomerId { get; set; }
    public string Product { get; set; }
}