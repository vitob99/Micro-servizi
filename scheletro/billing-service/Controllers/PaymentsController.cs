using BillingService.Data;
using BillingService.Models;
using BillingService.Services;
using Microsoft.AspNetCore.Mvc;

namespace BillingService.Controllers;

[ApiController]
[Route("subscriptions")]
public class PaymentsController : ControllerBase
{
    private readonly BillingDbContext _db;
    private readonly UserClient _userClient;

    public PaymentsController(BillingDbContext db, UserClient userClient)
    {
        _db = db;
        _userClient = userClient;
    }

    public class PaySubscriptionRequest
    {
        public int UserId { get; set; }
        public decimal Amount { get; set; }
    }

    // TODO STUDENTE:
    // Implementare la logica di pagamento abbonamento:
    //  - Verificare che l'utente esista chiamando UserClient.GetUserAsync
    //  - Salvare un record Payment
    //  - Convertire Amount in crediti (es. 1 euro = 10 crediti)
    //  - Chiamare user-service (endpoint /users/{id}/credits/add) per aggiornare i crediti
    //  - Restituire un risultato con i nuovi crediti
    [HttpPost("pay")]
    public async Task<ActionResult> PaySubscription([FromBody] PaySubscriptionRequest request)
    {
        throw new NotImplementedException("Da implementare: pagamento abbonamento e ricarica crediti");
    }
}

