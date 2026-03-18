using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingService.Models;

[Table("usage_record")]
public class UsageRecord
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
    public int Id{ get; set; }

    [Required]
    [Column("user_id")]
    public int UserId{ get; set; }

    [Required]
    [Column("occured_at")]    
    public DateTime OccurredAt{ get; set; } //data/ora dell’uso.

    [Column("usage_type")]  
    public string? UsageType{ get; set; } //tipo di utilizzo (es. "Deployment", "JobRun", ...).

    [Column("units")]  
    public int Units{ get; set; } //unità di utilizzo da addebitare (es. 1 per ogni deploy, oppure il numero di minuti/risorse consumate).

    [MaxLength(200)]
    [Column("description")]  
    public string? Description{ get; set; } //per dettagli.
}