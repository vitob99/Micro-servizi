using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingService.Models;

[Table("credit_transaction")]
public class CreditTransaction
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
    public int Id { get; set; }

    [Required]
    [Column("user_id")]
    public int UserId { get; set; }

    [Required]
    [Column("delta_credits")]
    public int DeltaCredits { get; set; }

    [Required]
    [Column("reason")]
    public string Reason { get; set; } = string.Empty;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [MaxLength(100)]
    [Column("source")]
    public string Source{ get; set; } = string.Empty; //origine della variazione crediti (es. "Purchase", "Bonus", "Adjustment", "Usage");

    [MaxLength(200)]
    [Column("notes")]
    public string? Notes{ get; set; }  //per informazioni aggiuntive.
}

