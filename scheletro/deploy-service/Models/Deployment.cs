namespace DeployService.Models;

public class Deployment
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string ProductId { get; set; } = string.Empty;
    public int ResourceUnits { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

