public class HRRecordDto
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Guid EmployeeId { get; set; }
    public string EventType { get; set; } // E.g., Hire, Termination, Promotion, etc.
    public int SatisfactionScore { get; set; } // For Employee Satisfaction Index
    public int TrainingHours { get; set; } // For Training Hours per Employee
    public int AbsenteeismDays { get; set; } // For Absenteeism Rate
    public int ProductivityScore { get; set; } // For Employee Productivity Rate
    public bool IsDiverse { get; set; } // For Diversity and Inclusion Metrics
}