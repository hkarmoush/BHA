public class CustomerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public decimal AcquisitionCost { get; set; }
    public decimal CustomerSatisfactionScore { get; set; }
    public decimal CustomerLifetimeValue { get; set; }
    public int NetPromoterScore { get; set; }
}