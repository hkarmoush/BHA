public class EmployeeRecordDto
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Guid EmployeeId { get; set; }
    public string EventType { get; set; }
    public int SatisfactionScore { get; set; }
    public int TrainingHours { get; set; }
    public int AbsenteeismDays { get; set; }
    public int ProductivityScore { get; set; }
    public bool IsDiverse { get; set; }
}