using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingService.Models;

[Table("invoice")]
public class Invoice
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
    public int Id{ get; set; }

    [Required]
    [Column("user_id")]
    public int UserId{ get; set; }
    
    [Required]
    [Column("issue_date")]
    public DateTime IssueDate{ get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    [Column("total_amount")]
    public decimal TotalAmount{ get; set; }

    [Required]
    [MaxLength(20)]
    [Column("status")]
    public string? Status{ get; set; }   // es. "Draft", "Issued", "Paid", "Cancelled".
}