using BillingService.Data;
using BillingService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillingService.Controllers;

[ApiController]
[Route("usage")]
public class UsageController : ControllerBase
{
    private readonly BillingDbContext _db;

    public UsageController(BillingDbContext db)
    {
        _db = db;
    }

    public class ConsumeCreditsRequest
    {
        public int UserId { get; set; }
        public int ResourceUnits { get; set; }
    }

    // TODO STUDENTE:
    // Implementare la logica di consumo crediti:
    //  - Calcolare quanti crediti servono per ResourceUnits (es. 1 unit = 1 credito)
    //  - Calcolare il saldo attuale dei crediti dell'utente (sommando CreditTransactions)
    //  - Se i crediti non bastano, restituire 400 BadRequest con messaggio "crediti insufficienti"
    //  - Altrimenti salvare una nuova CreditTransaction con DeltaCredits negativo
    [HttpPost("consume")]
    public async Task<ActionResult> ConsumeCredits([FromBody] ConsumeCreditsRequest request)
    {
        throw new NotImplementedException("Da implementare: consumo crediti in base all'uso delle risorse");
    }
}

