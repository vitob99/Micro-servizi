using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Models;
[Table("subscription_plans")]
public class SubscriptionPlan
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
    public int Id{ get; set; }

    [Required]
    [MaxLength(100)]
    [Column("name")]
    public string Name{ get; set; } = string.Empty; 

    [Required]
    [Column("monthly_cost")]
    public decimal MonthlyCost{ get; set; }

    [Required]
    [Column("max_credits_month")]
    public int MaxCreditsPerMonth{ get; set; } //numero massimo di crediti assegnati ogni mese agli utenti con questo piano


    public List<User> Users { get; set; } = new List<User>();
}