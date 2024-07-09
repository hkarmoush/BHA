public class ITRecordDto
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public decimal ITCosts { get; set; }
    public decimal ProjectCostVariance { get; set; }
    public int TicketsResolved { get; set; }
    public int TotalTickets { get; set; }
    public decimal SystemUptime { get; set; }
    public decimal SLACompliance { get; set; }
}