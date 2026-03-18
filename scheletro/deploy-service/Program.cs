using DeployService.Data;
using DeployService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default")
                      ?? builder.Configuration["ConnectionStrings__Default"];

builder.Services.AddDbContext<DeployDbContext>(options =>
    options.UseMySql(
        connectionString!,
        new MySqlServerVersion(new Version(8, 0, 0))));

builder.Services.AddHttpClient<BillingClient>((sp, client) =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var baseUrl = config["BillingServiceUrl"] ?? "http://billing-service";
    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// TODO STUDENTE: opzionale, migrazioni automatiche del DB
// using (var scope = app.Services.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<DeployDbContext>();
//     db.Database.Migrate();
// }

/*
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
*/

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

