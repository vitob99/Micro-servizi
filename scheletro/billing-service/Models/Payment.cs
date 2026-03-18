using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingService.Models;

[Table("payment")]
public class Payment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
    public int Id { get; set; }

    [Required]
    [Column("user_id")]
    public int UserId { get; set; }

    [Required]
    [ForeignKey("InvoiceId")]
    [Column("invoice_id")]
    public int InvoiceId { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    [Column("amount")]
    public decimal Amount { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    [MaxLength(100)]
    [Column("payment_method")]
    public string PaymentMethod { get; set; } = "CreditCard"; //es. "CreditCard", "PayPal", "BankTransfer".


    [MaxLength(200)]
    [Column("description")]
    public string? Description { get; set; }  //descrizione opzionale del pagamento (es. "Pagamento abbonamento Pro – Marzo 2026").

    [Required]
    [MaxLength(3)]
    [Column("currency")]
    public string Currency { get; set; } = "EUR";   //es. "EUR", "USD" valuta del pagamento
}

