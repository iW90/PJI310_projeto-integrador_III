using Microsoft.EntityFrameworkCore;
using OrcamentoEletricoApp.Mappings;
using OrcamentoEletricoApp.Services;
using OrcamentoEletricoDomain.Interfaces;
using OrcamentoEletricoDomain.Interfaces.Repositories;
using OrcamentoEletricoDomain.Interfaces.Services;
using OrcamentoEletricoInfra.Database;
using OrcamentoEletricoInfra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configurar o Kestrel para escutar externamente (necessário no Docker)
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000);
});

// BACKEND CONFIG

// Configure AutoMapper.
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Configure Logger
builder.Services.AddLogging(builder => builder.AddConsole());

// Configure Dependency Injection
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<IOrcamentoService, OrcamentoService>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IOrcamentoRepository, OrcamentoRepository>();

// Configura a string de conexao (Defina uma: "DefaultConnectionMySQL para local, ou DefaultConnection para Railway")
// var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionMySQL");

var host = Environment.GetEnvironmentVariable("MYSQLHOST");
var port = Environment.GetEnvironmentVariable("MYSQLPORT") ?? "3306";
var database = Environment.GetEnvironmentVariable("MYSQLDATABASE");
var username = Environment.GetEnvironmentVariable("MYSQLUSER");
var password = Environment.GetEnvironmentVariable("MYSQLPASSWORD");

Console.WriteLine("MySQL Connection Variables:");
Console.WriteLine($"Host: {host}");
Console.WriteLine($"Port: {port}");
Console.WriteLine($"Database: {database}");
Console.WriteLine($"User: {username}");

string connectionString;

if (!string.IsNullOrEmpty(host) && !string.IsNullOrEmpty(database) && !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
{
    connectionString = $"Server={host};Port={port};Database={database};Uid={username};Pwd={password};";
}
else
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnectionMySQL");
}

// Configura o DbContext com o MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Apply migrations automatically
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();