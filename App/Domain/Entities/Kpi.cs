public class Kpi
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Value { get; set; }
    public Role Role { get; set; } // Role that is allowed to view this KPI
}