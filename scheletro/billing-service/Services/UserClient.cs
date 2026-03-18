using System.Net.Http.Json;

namespace BillingService.Services;

public class UserClient
{
    private readonly HttpClient _httpClient;

    public UserClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // DTO minimale per comunicare con user-service
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Name { get; set; }
        public int Credits { get; set; }
    }

    // TODO STUDENTE:
    // Implementare la chiamata HTTP a user-service:
    //  - GET /users/{userId}
    //  - Gestire il caso 404 (utente non trovato) restituendo null
    public virtual async Task<UserDto?> GetUserAsync(int userId)
    {
        throw new NotImplementedException("Da implementare: chiamata HTTP a user-service per recuperare l'utente");
    }
}

