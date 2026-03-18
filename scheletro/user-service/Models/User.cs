using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserService.Models;

[Table("users")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
    public int Id { get; set; }

    // TODO STUDENTE: decidi quali proprietà devono essere obbligatorie
    [Required]
    [MaxLength(200)]
    [Column("email")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    // Crediti disponibili per l'utente (usati da Billing/Deploy)
    [Required]
    [Column("credits")]
    public int Credits { get; set; } = 0;

    [Required]
    [Column("registration_date")]
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;  //data di registrazione dell’utente

    [Required]
    [Column("is_active")]
    public bool IsActive { get; set; } = true; //indica se l’utente è attivo o disattivato.

    [Required]
    [MaxLength(15)]
    [Column("subscription_plan")]
    public string SubscriptionPlan { get; set; } = "Free"; //nome del piano di abbonamento (es. "Free", "Pro", "Enterprise").

    [Column("subscription_plan_id")]
    public int? SubscriptionPlanId { get; set; }

    [ForeignKey("SubscriptionPlanId")]
    public SubscriptionPlan? SubscriptionPlanForeignSet { get; set; }
}

