using System.ComponentModel.DataAnnotations;

namespace UserService.Models;

public class User
{
    public int Id { get; set; }

    // TODO STUDENTE: decidi quali proprietà devono essere obbligatorie
    [Required]
    [MaxLength(200)]
    public string Email { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? Name { get; set; }

    // Crediti disponibili per l'utente (usati da Billing/Deploy)
    public int Credits { get; set; }
}

