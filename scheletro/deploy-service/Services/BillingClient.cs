using System.Net.Http.Json;

namespace DeployService.Services;

public class BillingClient
{
    private readonly HttpClient _httpClient;

    public BillingClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public class ConsumeCreditsRequest
    {
        public int UserId { get; set; }
        public int ResourceUnits { get; set; }
    }

    // TODO STUDENTE:
    // Implementare la chiamata HTTP a billing-service:
    //  - POST /usage/consume con UserId e ResourceUnits
    //  - Restituire true/false in base al fatto che i crediti siano sufficienti
    public virtual async Task<bool> ConsumeCreditsAsync(int userId, int resourceUnits)
    {
        throw new NotImplementedException("Da implementare: chiamata HTTP a billing-service per consumo crediti");
    }
}

