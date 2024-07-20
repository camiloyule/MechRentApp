using MechRent.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MechRent.Application;
using Microsoft.Data.SqlClient;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//SqlConnectionStringBuilder tocnnect = new SqlConnectionStringBuilder();
//tocnnect.DataSource = "(localdb)\\mssqllocaldb";
//tocnnect.InitialCatalog = "MerchRendDb";
//tocnnect.UserID = "test2";
//tocnnect.Password = "123456789000000";
//Console.WriteLine(tocnnect.ConnectionString);

// Register DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer((builder.Configuration.GetConnectionString("DefaultConnection"))));
//builder.Services.AddDbContext<AppDbContext>(options =>
//  options.UseSqlServer(tocnnect.ConnectionString));
//SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();





// Register repositories
builder.Services.AddScoped<IObraPublicaRepository, ObraPublicaRepository>();
builder.Services.AddScoped<IMaquinaRepository, MaquinaRepository>();

//// Register services
builder.Services.AddScoped<IObraPublicaService, ObraPublicaService>();

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Renta de maquinas de Construccion API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate(); // This will apply any pending migrations
        AppDbContext.SeedData(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

app.Run();
