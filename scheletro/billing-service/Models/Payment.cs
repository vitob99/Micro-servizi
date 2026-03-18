using System.ComponentModel.DataAnnotations;

namespace BillingService.Models;

public class Payment
{
    public int Id { get; set; }

    public int UserId { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Amount { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

