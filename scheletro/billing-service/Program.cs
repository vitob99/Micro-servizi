using Microsoft.EntityFrameworkCore;
using BillingService.Data;
using BillingService.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default")
                      ?? builder.Configuration["ConnectionStrings__Default"];

builder.Services.AddDbContext<BillingDbContext>(options =>
    options.UseMySql(
        connectionString!,
        new MySqlServerVersion(new Version(8, 0, 0))));

builder.Services.AddHttpClient<UserClient>((sp, client) =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var baseUrl = config["UserServiceUrl"] ?? "http://user-service";
    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// TODO STUDENTE: opzionale, abilitare migrazioni automatiche
// using (var scope = app.Services.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<BillingDbContext>();
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

