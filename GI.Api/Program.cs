using GI.Logging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuracion Serilog
var logsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
SerilogConfigurator.ConfigureGlobalLogger(logsDirectory);
builder.Host.UseSerilog(); // Configurar Serilog como proveedor de logging
builder.Services.AddLogging(); // Agregar ILogger al contenedor

//builder.Services.AddSingleton<IDbConfiguracion, DbConfiguracion>();
//builder.Services.InyeccionInfraestructura();
//builder.Services.InyeccionAplicacion();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
