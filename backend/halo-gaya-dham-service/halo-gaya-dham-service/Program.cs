using halo_gaya_dham_service.Config;
using Serilog;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

/* Logger */
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* Session */
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{ 
    options.IdleTimeout = TimeSpan.FromSeconds(100);
    options.Cookie.IsEssential = true;
});

DependencyInjectionConfig.Configure(builder.Services);

var app = builder.Build();

app.MapGet("/", () => "halo-gaya-dham-backend-service is up and running!");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseSession();

app.MapControllers();

app.Run();
