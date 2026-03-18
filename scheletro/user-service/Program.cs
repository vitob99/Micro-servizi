using Microsoft.EntityFrameworkCore;
using UserService.Data;

var builder = WebApplication.CreateBuilder(args);

// DbContext EF Core per MySQL - gli studenti vedranno come è configurato
var connectionString = builder.Configuration.GetConnectionString("Default") ?? builder.Configuration["ConnectionStrings__Default"];

builder.Services.AddDbContext<UserDbContext>(options => options.UseMySql(connectionString!, ServerVersion.AutoDetect(connectionString)));


//Ho commentato l'aggiunta dei controllers e degli endpoint delle api visto che non li utilizziamo al momento
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// TODO: Creare connessione api per le comunicazioni tra i micro-servizi
// // TODO: opzionale, far vedere agli studenti come usare le migrations
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<UserDbContext>();

    try
    {
        db.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Errore durante la migrazione: {ex.Message}");
    }
}





    app.UseSwagger();
    app.UseSwaggerUI();



app.UseHttpsRedirection();

app.MapControllers();

app.Run();