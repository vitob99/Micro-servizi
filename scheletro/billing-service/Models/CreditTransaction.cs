namespace BillingService.Models;

public class CreditTransaction
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int DeltaCredits { get; set; }
    public string Reason { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

