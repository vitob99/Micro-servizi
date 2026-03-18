using Microsoft.EntityFrameworkCore;
using UserService.Data;

// var builder = WebApplication.CreateBuilder(args);

// // DbContext EF Core per MySQL - gli studenti vedranno come è configurato
// var connectionString = builder.Configuration.GetConnectionString("Default")
//                       ?? builder.Configuration["ConnectionStrings__Default"];

// builder.Services.AddDbContext<UserDbContext>(options =>
//     options.UseMySql(
//         connectionString!,
//         new MySqlServerVersion(new Version(8, 0, 0))));

// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// TODO: opzionale, far vedere agli studenti come usare le migrations
// using (var scope = app.Services.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<UserDbContext>();
//     db.Database.Migrate();
// }




// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }


// app.UseHttpsRedirection();

// app.MapControllers();

// app.Run();


    Console.WriteLine("Prova");
