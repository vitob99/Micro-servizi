using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Models;

namespace UserService.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly UserDbContext _db;

    public UsersController(UserDbContext db)
    {
        _db = db;
    }

    // TODO STUDENTE:
    // Implementare la logica per creare un nuovo utente.
    // Suggerimento:
    //  - Leggere il body (User o un DTO)
    //  - Impostare Credits = 0 all'inizio
    //  - Salvare su database
    //  - Restituire 201 Created con l'utente creato
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser([FromBody] User user)
    {
        user.Credits = 0;

        _db.Users.Add(user);

        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    // TODO STUDENTE:
    // Implementare la logica per recuperare un utente per id.
    // Suggerimento:
    //  - Usare _db.Users.FindAsync(id) oppure FirstOrDefaultAsync
    //  - Se non trovato, restituire NotFound()
    [HttpGet("{id:int}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var user = await _db.Users.FindAsync(id);

        // Controlla se esiste
        if (user == null)
        {
            return NotFound("Utente non trovato"); // restituisce 404 se non trovato
        }

        return Ok(user); // restituisce 200 con l'utente
    }

    // Endpoint opzionale che può essere utile nella soluzione
    // per aggiornare i crediti da BillingService.
    //
    // TODO STUDENTE (avanzato / bonus):
    //  - Implementare un'azione che aggiorni i crediti dell'utente
    //    in base a un delta passato dal billing-service.
    [HttpPost("{id:int}/credits/add")]
    public async Task<ActionResult> AddCredits(int id, [FromBody] AddCreditsRequest request)
    {
        var user = await _db.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound($"Utente con id: {id} non trovato!");
        }

        // Aggiungo i crediti
        user.Credits += request.Delta;

        // Salvo i cambiamenti nel db
        await _db.SaveChangesAsync();

        // Ritorno il success dell'id dello user e i crediti disponibili
        return Ok(new { user.Id, user.Credits });
    }

    [HttpGet("{id:int}/registration")]
    public async Task<ActionResult<User>> GetRegistrationDate(int id)
    {
        User? user = _db.Users.FirstOrDefault(u => u.Id == id);  //cerco l'utente con id uguale al parametro

        if (user == null)//se nullo...
        {
            return NotFound($"Utente con ID {id} non trovato.");  
        }

        return Ok(user.RegistrationDate); //se trovato...
    }
}

public class AddCreditsRequest
{
    public int Delta { get; set; }
}

