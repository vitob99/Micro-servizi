using DeployService.Data;
using DeployService.Models;
using DeployService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeployService.Controllers;

[ApiController]
[Route("deploy")]
public class DeploymentsController : ControllerBase
{
    private readonly DeployDbContext _db;
    private readonly BillingClient _billingClient;

    public DeploymentsController(DeployDbContext db, BillingClient billingClient)
    {
        _db = db;
        _billingClient = billingClient;
    }

    public class DeployRequest
    {
        public int UserId { get; set; }
        public string ProductId { get; set; } = string.Empty;
        public int ResourceUnits { get; set; }
    }

    [HttpPost]
    public async Task<ActionResult> CreateDeployment([FromBody] DeployRequest request)
    {
        throw new NotImplementedException("Da implementare: registrazione deploy e chiamata a billing-service");
    }
}

