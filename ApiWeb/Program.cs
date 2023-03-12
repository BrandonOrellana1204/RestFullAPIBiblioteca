using ApiWeb;
using ApiWeb.Extenciones;
using Aplicacion;
using Aplicacion.Mappings;
using Compartir;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Persistencia;


var builder = WebApplication.CreateBuilder(args);

// services to the container.
var configuration = builder.Configuration;

builder.Services.CapaAPlicacion();
builder.Services.AddSharedInfraestructure(configuration);
builder.Services.AddPersitenceInfraestructure(configuration);
builder.Services.AgregarApiExtencion();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UsarMediadorErrores();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
