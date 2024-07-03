public class HRRecord
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Guid EmployeeId { get; set; }
    public string EventType { get; set; } // Hire, Promotion, Resignation, Termination, etc.
    public int SatisfactionScore { get; set; }
}