using GI.Api.Configuracion;
using GI.Aplicacion.Configuracion;
using GI.Infraestructura.Configuracion;
using GI.Infraestructura.Persistencia;
using GI.Logging;
using GS.Aplicacion.Comunes.AuditoriaHelper;
using Microsoft.AspNetCore.Mvc;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region CONFIGURACION SERILOG
    var logsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
    SerilogConfigurator.ConfigureGlobalLogger(logsDirectory);
    builder.Host.UseSerilog(); // Configurar Serilog como proveedor de logging
    builder.Services.AddLogging(); // Agregar ILogger al contenedor
#endregion

#region CONFIGURACION DE INYECCION DE DEPENCIAS
    builder.Services.AddSingleton<IDbConfiguracion, DbConfiguracion>();
    builder.Services.InyeccionInfraestructura();
    builder.Services.InyeccionAplicacion();
#endregion


var app = builder.Build();
#region MIDDLEWARE
    app.UseMiddleware<AuditoriaMiddleware>();
#endregion


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
